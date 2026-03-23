using System.Collections.Generic;
using System.Linq;

namespace MonoTile
{
    public class TiledMap : IMap
    {
        public int Width, Height;
        public int TileWidth, TileHeight;

        public string Orientation;
        public string RenderOrder;
        public bool Infinite;

        public List<Tileset> Tilesets = new();
        public List<Layer> Layers = new();

        public TilemapStruct ToMap()
        {
            var firstLayer = Layers.FirstOrDefault();
            if (firstLayer == null)
                return default;

            var firstTileset = Tilesets.FirstOrDefault();

            return new TilemapStruct
            {
                Width = firstLayer.Width,
                Height = firstLayer.Height,
                TileWidth = firstTileset?.TileWidth ?? 16,
                TileHeight = firstTileset?.TileHeight ?? 16,
                Tiles = firstLayer.Tiles,
                Tileset = new TilemapStruct.TilesetStruct
                {
                    ImageSource = firstTileset?.ImageSource ?? "",
                    TileWidth = firstTileset?.TileWidth ?? 16,
                    TileHeight = firstTileset?.TileHeight ?? 16,
                    Columns = firstTileset?.Columns ?? 0,
                    TileCount = firstTileset?.TileCount ?? 0,
                    FirstGid = firstTileset?.FirstGid ?? 1
                }
            };
        }

        public class Tileset
        {
            public int FirstGid;
            public string Name;
            public int TileWidth, TileHeight;
            public int TileCount, Columns;

            public string ImageSource;
            public int ImageWidth, ImageHeight;
        }

        public class Layer
        {
            public int Id;
            public string Name;
            public int Width, Height;
            public Dictionary<string, object> Properties = new();
            public int[,] Tiles;
        }
    }
}