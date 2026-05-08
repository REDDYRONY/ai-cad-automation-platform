namespace backend.Models
{
    public class CadParameters
    {
        public string Component { get; set; } = "";

        public double ShaftDiameter { get; set; }

        public string Material { get; set; } = "";

        public double HousingLength { get; set; }

        public double HousingWidth { get; set; }

        public double HousingHeight { get; set; }

        public double MountingHoleDiameter { get; set; }

        public int MountingHoleCount { get; set; }
    }
}