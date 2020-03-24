namespace DibryBand
{
    public class KeyboardTimbre : ITimbre
    {
        public EmotionType EmotionType { get; set; }
        public bool Loud { get; set; }

        public string Emit()
        {
            string volume = Loud ? "loudly" : "quietly";
            return $" keys pressed {EmotionType} {volume}";
        }
    }
}
