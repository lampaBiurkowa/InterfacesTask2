namespace DibryBand
{
    public interface IGuitar : IInstrument
    {
        int StringCount { get; }

        GuitarTimbre Jerk();
    }
}
