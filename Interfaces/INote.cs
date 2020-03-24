namespace DibryBand
{
    public interface INote
    {
        float Frequency { get; }

        void Display();
        GuitarTimbre Jerk(); 
    }
}
