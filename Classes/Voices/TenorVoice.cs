using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class TenorVoice : IMaleVoice
    {
        public float MaxFrequency => FrequencyMapper.GetHzFromNote("C5");
        public float MinFrequency => FrequencyMapper.GetHzFromNote("A2");

        public VoiceTimbre EmitNormally(EmotionType emotion)
        {
            return new VoiceTimbre
            {
                EmotionType = emotion,
                Loud = true,
                Harsh = false,
                Punchy = false
            };
        }

        public VoiceTimbre EmitHarshly(EmotionType emotion)
        {
            return new VoiceTimbre
            {
                EmotionType = emotion,
                Loud = false,
                Harsh = true,
                Punchy = false
            };
        }

        public VoiceTimbre EmitFalsetto(EmotionType emotion)
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
                if (note >= FrequencyMapper.GetHzFromNote("B4") && (emotion == EmotionType.Subtle || emotion == EmotionType.Sad))
                    timbre = EmitFalsetto(emotion);
                else if (emotion == EmotionType.Aggressive)
                    timbre = EmitHarshly(emotion);
                else
                    timbre = EmitNormally(emotion);

                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note)} with timbre {timbre.Emit()}");
            }
        }
    }
}
