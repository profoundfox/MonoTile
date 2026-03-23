using System;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;

namespace MonoTile
{
    public class TiledLoader : ITileLoader<TiledMap>
    {
        public static TiledMap Extract(string path)
        {
            var doc = XDocument.Load(path); 
            var mapEl = doc.Element("map");

            var map = new TiledMap
            {
                Width = (int)mapEl.Attribute("width"),
                Height = (int)mapEl.Attribute("height"),
                TileWidth = (int)mapEl.Attribute("tilewidth"),
                TileHeight = (int)mapEl.Attribute("tileheight"),
                Orientation = (string)mapEl.Attribute("orientation"),
                RenderOrder = (string)mapEl.Attribute("renderorder"),
                Infinite = ((int?)mapEl.Attribute("infinite") ?? 0) == 1
            };

            foreach (var ts in mapEl.Elements("tileset"))
            {
                var image = ts.Element("image");

                map.Tilesets.Add(new TiledMap.Tileset
                {
                    FirstGid = (int)ts.Attribute("firstgid"),
                    Name = (string)ts.Attribute("name"),
                    TileWidth = (int)ts.Attribute("tilewidth"),
                    TileHeight = (int)ts.Attribute("tileheight"),
                    TileCount = (int)ts.Attribute("tilecount"),
                    Columns = (int)ts.Attribute("columns"),

                    ImageSource = (string)image?.Attribute("source"),
                    ImageWidth = (int?)image?.Attribute("width") ?? 0,
                    ImageHeight = (int?)image?.Attribute("height") ?? 0
                });
            }

            foreach (var layerEl in mapEl.Elements("layer"))
            {
                var layer = new TiledMap.Layer
                {
                    Id = (int)layerEl.Attribute("id"),
                    Name = (string)layerEl.Attribute("name"),
                    Width = (int)layerEl.Attribute("width"),
                    Height = (int)layerEl.Attribute("height")
                };

                var props = layerEl.Element("properties");
                if (props != null)
                {
                    foreach (var p in props.Elements("property"))
                    {
                        string name = (string)p.Attribute("name");
                        string type = (string)p.Attribute("type") ?? "string";
                        string value = (string)p.Attribute("value") ?? p.Value;

                        layer.Properties[name] = Parsers.ParseProperty(type, value);
                    }
                }

                var dataEl = layerEl.Element("data");
                string encoding = (string)dataEl.Attribute("encoding");

                if (encoding != "csv")
                    throw new NotSupportedException("Only CSV supported in this version");
                
                var numbers = dataEl.Value
                    .Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(int.Parse)
                    .ToArray();
                
                layer.Tiles = new int[layer.Width, layer.Height];

                for(int y = 0; y < layer.Height; y++)
                {
                    for(int x = 0; x < layer.Width; x++)
                    {
                        layer.Tiles[x, y] = numbers[y * layer.Width + x];
                    }
                }

                map.Layers.Add(layer);

            }

            return map;
        }
    }
}