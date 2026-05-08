using backend.Models;

namespace backend.Services
{
    public class OnshapePayloadService
    {
        public List<OnshapeVariable>
            GenerateVariables(
                CadParameters parameters
            )
        {
            return new List<OnshapeVariable>
            {
                new OnshapeVariable
                {
                    Name = "shaft_diameter",
                    Value =
                        $"{parameters.ShaftDiameter} mm"
                },

                new OnshapeVariable
                {
                    Name = "housing_length",
                    Value =
                        $"{parameters.HousingLength} mm"
                },

                new OnshapeVariable
                {
                    Name = "housing_width",
                    Value =
                        $"{parameters.HousingWidth} mm"
                },

                new OnshapeVariable
                {
                    Name = "housing_height",
                    Value =
                        $"{parameters.HousingHeight} mm"
                },

                new OnshapeVariable
                {
                    Name =
                        "mounting_hole_diameter",

                    Value =
                        $"{parameters.MountingHoleDiameter} mm"
                }
            };
        }
    }
}