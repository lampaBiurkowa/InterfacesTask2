namespace DibryBand
{
    public class GuitarTimbre : ITimbre
    {
        public bool Dynamic { get; set; }
        public bool Loud { get; set; }
        public bool Synthetic { get; set; }

        public string Emit()
        {
            string volume = Loud ? "loudly" : "quietly";
            string dynamic = Dynamic ? "dynamicly" : "";
            string type = Synthetic ? "synteticly" : "acousticly";
            return $" jerked {volume} {type} {dynamic}";
        }
    }
}
