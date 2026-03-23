using System;

namespace MonoTile
{
    public static class Parsers
    {
        public static object ParseProperty(string type, string value)
        {
            type ??= "string";

            return type switch
            {
                "bool" => value == "true",
                "int" => int.Parse(value),
                "float" => float.Parse(value, System.Globalization.CultureInfo.InvariantCulture),
                "color" => ParseColor(value),
                "file" => value,
                "object" => int.Parse(value),
                _ => value
            };
        }

        public static (byte r, byte g, byte b, byte a) ParseColor(string hex)
        {
            hex = hex.TrimStart('#');

            if (hex.Length == 6)
            {
                return (
                    Convert.ToByte(hex.Substring(0, 2), 16),
                    Convert.ToByte(hex.Substring(2, 2), 16),
                    Convert.ToByte(hex.Substring(4, 2), 16),
                    255
                );
            }
            else if (hex.Length == 8)
            {
                return (
                    Convert.ToByte(hex.Substring(2, 2), 16),
                    Convert.ToByte(hex.Substring(4, 2), 16),
                    Convert.ToByte(hex.Substring(6, 2), 16),
                    Convert.ToByte(hex.Substring(0, 2), 16)
                );
            }

            throw new Exception("Invalid color format");
        }
    }
}