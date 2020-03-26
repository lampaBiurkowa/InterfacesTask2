using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class SopranoVoice : IFemaleVoice
    {
        public float MinFrequency => FrequencyMapper.GetHzFromNote("A4");
        public float MaxFrequency => FrequencyMapper.GetHzFromNote("C6");

        public VoiceTimbre EmitNormally(EmotionType emotion)
        {
            return new VoiceTimbre
            {
                EmotionType = emotion,
                Loud = false,
                Harsh = false,
                Punchy = false
            };
        }

        public VoiceTimbre EmitScream(EmotionType emotion)
        {
            return new VoiceTimbre
            {
                EmotionType = emotion,
                Loud = true,
                Harsh = false,
                Punchy = true
            };
        }

        public void Play(IList<float> notes)
        {
            Random random = new Random();
            foreach (var note in notes)
            {
                if (note > MaxFrequency || note < MinFrequency)
                {
                    Console.WriteLine("I can't sing it!");
                    continue;
                }

                VoiceTimbre timbre;
                EmotionType emotion = (EmotionType)random.Next(0, 3);
                if (note >= FrequencyMapper.GetHzFromNote("D5") && emotion == EmotionType.Aggressive)
                    timbre = EmitScream(emotion);
                else
                    timbre = EmitNormally(emotion);

                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note)} with timbre {timbre.Emit()}");
            }
        }
    }
}
