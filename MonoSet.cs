using System.Collections.Generic;

namespace MonoTile
{
    public struct MonoSet 
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public string ImagePath { get; set; }

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }

        public Dictionary<int, Dictionary<string, object>> TileProperties { get; set; }

        public MonoSet(int rows, int columns, string imagePath,
            int tileWidth, int tileHeight, Dictionary<int,Dictionary<string, object>> tileProps)
        {
          Rows = rows;
          Columns = columns;
          ImagePath = imagePath;
          TileWidth = tileWidth;
          TileHeight = tileHeight;
          TileProperties = tileProps;
        }
    }
}
