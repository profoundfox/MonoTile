
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;

namespace MonoTile
{
    public class SpriteFusionLoader : ITileLoader<SpriteFusionMap>
    {
        public static SpriteFusionMap Extract(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found at {path}");

            string json = File.ReadAllText(path);

            try
            {
                return JsonSerializer.Deserialize<SpriteFusionMap>(json);
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to parse SPMap JSON: {e.Message}", e);
            }
        }
    }
}
