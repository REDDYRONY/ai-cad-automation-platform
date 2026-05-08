using backend.Models;

namespace backend.Rules
{
    public static class BearingHousingRules
    {
        public static void Apply(CadParameters result)
        {
            if (result.ShaftDiameter <= 0)
            {
                result.ShaftDiameter = 25;
            }

            if (string.IsNullOrEmpty(result.Component))
{
    result.Component = "Bearing Housing";
}
            {
                result.Material = "Cast Iron";
            }

            if (result.HousingLength <= 0)
            {
                result.HousingLength =
                    result.ShaftDiameter * 3;
            }

            if (result.HousingWidth <= 0)
            {
                result.HousingWidth =
                    result.ShaftDiameter * 2;
            }

            if (result.HousingHeight <= 0)
            {
                result.HousingHeight =
                    result.ShaftDiameter * 2;
            }

            if (result.MountingHoleDiameter <= 0)
            {
                result.MountingHoleDiameter = 10;
            }

            if (result.MountingHoleCount <= 0)
            {
                result.MountingHoleCount = 4;
            }
        }
    }
}