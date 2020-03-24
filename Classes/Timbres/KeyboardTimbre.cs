namespace DibryBand
{
    public class KeyboardTimbre : ITimbre
    {
        public EmotionType EmotionType { get; set; }
        public bool Dynamic { get; set; }
        public bool Loud { get; set; }

        public string Emit()
        {
            string volume = Loud ? "loudly" : "quietly";
            string dynamic = Dynamic ? "dynamicly" : "";
            return $" keys pressed {EmotionType} {dynamic} {volume}";
        }
    }
}
