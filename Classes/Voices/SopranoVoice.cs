using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class SopranoVoice : IFemaleVoice
    {
        public float MaxFrequency => FrequencyMapper.GetHzFromNote("A4");
        public float MinFrequency => FrequencyMapper.GetHzFromNote("C6");

        public VoiceTimbre EmitNormally(EmotionType emotion)
        {
            VoiceTimbre timbre = new VoiceTimbre();
            timbre.EmotionType = emotion;
            timbre.Loud = false;
            timbre.Harsh = false;
            timbre.Punchy = false;

            return timbre;
        }

        public VoiceTimbre EmitScream(EmotionType emotion)
        {
            VoiceTimbre timbre = new VoiceTimbre();
            timbre.EmotionType = emotion;
            timbre.Loud = true;
            timbre.Harsh = false;
            timbre.Punchy = true;

            return timbre;
        }

        public void Play(IList<INote> notes)
        {
            Random random = new Random();
            foreach (var note in notes)
            {
                VoiceTimbre timbre;
                EmotionType emotion = (EmotionType)random.Next(0, 3);
                if (note.Frequency >= FrequencyMapper.GetHzFromNote("D5") && emotion == EmotionType.Aggressive)
                    timbre = EmitScream(emotion);
                else
                    timbre = EmitNormally(emotion);

                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note.Frequency)} with timbre {timbre.Emit()}");
            }
        }
    }
}
