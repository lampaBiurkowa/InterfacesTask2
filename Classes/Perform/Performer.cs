using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class Performer
    {
        private IGuitar guitar;
        private IVoice voice;

        public Performer(IGuitar guitar, IVoice voice)
        {
            this.guitar = guitar;
            this.voice = voice;
        }

        public void PlayGuitar(IList<float> notes)
        {
            guitar.Play(notes);
        }

        public void Sing(IList<float> notes)
        {
            voice.Play(notes);
        }
    }
}
