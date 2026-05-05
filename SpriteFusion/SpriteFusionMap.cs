using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MonoTile
{
    public struct SpriteFusionMap : IMap
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tileSize")]
        public int TileSize { get; set; }

        [JsonPropertyName("spriteSheets")]
        public Dictionary<string, SpriteSheet> SpriteSheets { get; set; }

        [JsonPropertyName("mapWidth")]
        public int MapWidth { get; set; }

        [JsonPropertyName("mapHeight")]
        public int MapHeight { get; set; }

        [JsonPropertyName("layers")]
        public List<Layer> Layers { get; set; }

        public List<MonoMap> ToMaps()
        {
            throw new NotImplementedException();
        }

        public struct SpriteSheet
        {
            [JsonPropertyName("base64")]
            public string Base64 { get; set; }
        }

        public struct Layer
        {
            [JsonPropertyName("id")]
            public string ID { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("tiles")]
            public List<Tile> Tiles { get; set; }

            [JsonPropertyName("collider")]
            public bool Collider { get; set; }
        }

        public struct Tile
        {
            [JsonPropertyName("id")]
            public string ID { get; set; }

            [JsonPropertyName("x")]
            public int X { get; set; }

            [JsonPropertyName("y")]
            public int Y { get; set; }

            [JsonPropertyName("spriteSheetId")]
            public string SpriteSheetID { get; set; }

            [JsonPropertyName("scaleY")]
            public int ScaleX { get; set; }

            [JsonPropertyName("scaleX")]
            public int ScaleY { get; set; }
        }

        public struct Attribute
        {
            [JsonPropertyName("id")]
            public string ID { get; set; }

            [JsonPropertyName("key")]
            public string Key { get; set; }

            [JsonPropertyName("value")]
            public string Value { get; set; }
        }
    }
}
