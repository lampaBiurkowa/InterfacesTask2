using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class Organ : IKeyboard
    {
        public KeyboardTimbre PressKey(EmotionType emotion)
        {
            KeyboardTimbre timbre = new KeyboardTimbre();
            timbre.EmotionType = emotion;
            timbre.Dynamic = false;
            timbre.Loud = true;
            return timbre;
        }

        public void Play(IList<float> notes)
        {
            Random random = new Random();
            foreach (var note in notes)
            {
                EmotionType emotion = (EmotionType)random.Next(0, 3);
                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note)} with timbre {PressKey(emotion).Emit()}");
            }
        }
    }
}
