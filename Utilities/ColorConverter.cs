using System.Drawing;

namespace RestSharpAPI.Utilities;

    public static class ColorConverter
    {
        public static string ConvertColorNameToHex(string colorName)
        {
            try
            {
                Color color = Color.FromName(colorName);
                return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            }
            catch (Exception)
            {
                // If color name is not recognized, return a default color
                return "#000000"; // Default to black
            }
        }
    }