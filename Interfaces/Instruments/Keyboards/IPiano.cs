namespace DibryBand
{
    public interface IPiano
    {
        public bool TwoHandsRequired { get; set; }

        KeyboardTimbre PressKey();
    }
}
