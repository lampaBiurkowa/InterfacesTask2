using System.Collections.Generic;

namespace DibryBand
{
    public interface IInstrument
    {
        void Play(IList<INote> notes);
    }
}
