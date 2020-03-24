using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class AltoVoice : IFemaleVoice
    {
        public float MinFrequency => FrequencyMapper.GetHzFromNote("E3");
        public float MaxFrequency => FrequencyMapper.GetHzFromNote("G5");

        public VoiceTimbre EmitNormally(EmotionType emotion)
        {
            VoiceTimbre timbre = new VoiceTimbre();
            timbre.EmotionType = emotion;
            timbre.Loud = true;
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
                if (note >= FrequencyMapper.GetHzFromNote("C5") && (emotion == EmotionType.Aggressive || emotion == EmotionType.Happy))
                    timbre = EmitScream(emotion);
                else
                    timbre = EmitNormally(emotion);

                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note)} with timbre {timbre.Emit()}");
            }
        }
    }
}
