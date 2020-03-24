using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class Piano : IKeyboard
    {
        public KeyboardTimbre PressKey(EmotionType emotion)
        {
            KeyboardTimbre timbre = new KeyboardTimbre();
            timbre.EmotionType = emotion;
            timbre.Dynamic = true;
            timbre.Loud = false;
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
