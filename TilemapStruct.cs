namespace MonoTile
{
    public struct TilemapStruct
    {
        public int Width, Height;
        public int TileWidth, TileHeight;

        public int[,] Tiles;
        public TilesetStruct Tileset;

        public struct TilesetStruct
        {
            public string ImageSource;
            public int TileWidth, TileHeight;
            public int Columns, TileCount;
            public int FirstGid;
        }
    }
}