using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class AltoVoice : IFemaleVoice
    {
        public float MaxFrequency => FrequencyMapper.GetHzFromNote("E3");
        public float MinFrequency => FrequencyMapper.GetHzFromNote("G5");

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

        public void Play(IList<INote> notes)
        {
            Random random = new Random();
            foreach (var note in notes)
            {
                VoiceTimbre timbre;
                EmotionType emotion = (EmotionType)random.Next(0, 3);
                if (note.Frequency >= FrequencyMapper.GetHzFromNote("C5") && (emotion == EmotionType.Aggressive || emotion == EmotionType.Happy))
                    timbre = EmitScream(emotion);
                else
                    timbre = EmitNormally(emotion);

                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note.Frequency)} with timbre {timbre.Emit()}");
            }
        }
    }
}
