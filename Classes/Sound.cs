using System.Collections.Generic;
using System.Linq;

namespace DibryBand
{
    public enum EmotionType
    {
        Aggressive, Happy, Subtle, Sad
    }

    public static class FrequencyMapper
    {
        private const float FACTOR = 1.12f;
        private const float C1_FREQUENCY_HZ = 32.703f;
        private const int OCTAVES_COUNT = 8;
        private const int STARTING_OCTAVE = 1;

        private static Dictionary<string, float> mapperToHz = new Dictionary<string, float>();
        private static Dictionary<float, string> mapperToNote = new Dictionary<float, string>();
        private static string[] letters = { "C", "D", "E", "F", "G", "A", "B" };

        static FrequencyMapper()
        {
            float currentFrequency = C1_FREQUENCY_HZ;
            for (int i = STARTING_OCTAVE; i < OCTAVES_COUNT; i++)
                for (int j = 0; j < letters.Length; j++)
                {
                    mapperToHz.Add($"{letters[j]}{i}", currentFrequency);
                    mapperToNote.Add(currentFrequency, $"{letters[j]}{i}");
                    currentFrequency *= FACTOR;
                }
        }

        public static float GetHzFromNote(string note)
        {
            return mapperToHz[note];
        }

        public static string GetNoteFromHz(float frequency)
        {
            var bigger = mapperToNote.Where(element => element.Key >= frequency);
            return bigger.Any() ? bigger.Aggregate((e1, e2) => e1.Key < e2.Key ? e1 : e2).Value : mapperToNote[C1_FREQUENCY_HZ];
        }
    }
}
