using System.Collections.Generic;
using System.Linq;

namespace DibryBand
{
    public enum EmotionType
    {
        Aggressive, Happy, Subtle, Sad
    }

    public sealed class FrequencyMapper
    {
        private const float FACTOR = 1.12f;
        private const float C1_FREQUENCY_HZ = 32.703f;
        private const int OCTAVES_COUNT = 8;
        private const int STARTING_OCTAVE = 1;

        private Dictionary<string, float> mapperToHz = new Dictionary<string, float>();
        private Dictionary<float, string> mapperToNote = new Dictionary<float, string>();
        private string[] letters = { "C", "D", "E", "F", "G", "A", "B" };

        private static readonly FrequencyMapper instance = new FrequencyMapper();
        public static FrequencyMapper Instance
        {
            get
            {
                return instance;
            }
        }

        static FrequencyMapper()
        {
        }

        private FrequencyMapper()
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

        public float GetHzFromNote(string note)
        {
            return mapperToHz[note];
        }

        public string GetNoteFromHz(float frequency)
        {
            var bigger = mapperToNote.Where(element => element.Key >= frequency);
            return bigger.Any() ? bigger.Aggregate((e1, e2) => e1.Key < e2.Key ? e1 : e2).Value : mapperToNote[C1_FREQUENCY_HZ];
        }
    }
}
