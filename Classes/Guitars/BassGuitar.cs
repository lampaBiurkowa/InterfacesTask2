﻿using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class BassGuitar : IGuitar
    {
        public int StringCount { get; private set; }

        public GuitarTimbre Jerk()
        {
            GuitarTimbre timbre = new GuitarTimbre();
            timbre.Dynamic = false;
            timbre.Loud = false;
            timbre.Synthetic = false;
            return timbre;
        }

        public void Play(IList<INote> notes)
        {
            foreach (var note in notes)
                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note.Frequency)} with timbre {Jerk().Emit()}");
        }
    }
}