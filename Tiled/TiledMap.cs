using System;
using System.Collections.Generic;
using System.IO;
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

        public string FilePath;

        public List<MonoMap> ToMaps()
        {
            var result = new List<MonoMap>();

            if (Tilesets == null || Tilesets.Count == 0)
                return result;

            if (Layers == null || Layers.Count == 0)
                return result;

            var ts = Tilesets[0];

            var monoSet = new MonoSet(
                rows: ts.TileCount / ts.Columns,
                columns: ts.Columns,
                imagePath: ts.ImageSource,
                tileWidth: ts.TileWidth,
                tileHeight: ts.TileHeight,
                tileProps: ts.TileProperties
            );

            foreach (var layer in Layers)
            {
                var grid = layer.Tiles.CloneGrid();

                var monoMap = new MonoMap(
                    grid: grid,
                    tileSet: monoSet,
                    rows: layer.Height,
                    columns: layer.Width,
                    indexOffset: ts.FirstGid
                );

                monoMap.FilePath = FilePath;

                monoMap.Properties = layer.Properties;

                result.Add(monoMap);
            }

            return result;
        }

        private int[,] CloneGrid(int[,] source)
        {
            if (source == null)
                return null;

            int w = source.GetLength(0);
            int h = source.GetLength(1);

            var copy = new int[w, h];

            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                    copy[x, y] = source[x, y];

            return copy;
        }

        public class Tileset
        {
            public int FirstGid;
            public string Name;
            public int TileWidth, TileHeight;
            public int TileCount, Columns;

            public string ImageSource;
            public int ImageWidth, ImageHeight;

            public Dictionary<int, Dictionary<string, object>> TileProperties
                = new Dictionary<int, Dictionary<string, object>>();
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
