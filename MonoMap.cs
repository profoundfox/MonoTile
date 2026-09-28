using System.Collections.Generic;
using System.IO;

namespace MonoTile
{
  public struct MonoMap
  {
    private string filePath;

    public string FilePath
    {
      get => Path.GetDirectoryName(filePath);
      set => filePath = value;
    }

    public string Name { get; set; }

    public int[,] Grid { get; set; }

    public MonoSet TileSet { get; set; }

    public Dictionary<string, object> Properties { get; set; }

    public int Rows { get; set; }
    public int Columns { get; set; }

    public int IndexOffset { get; set; }

    public MonoMap(string name, int[,] grid, MonoSet tileSet, int rows,
        int columns, int indexOffset)
    {
      Name = name;
      Grid = grid;
      TileSet = tileSet;
      Rows = rows;
      Columns = columns;
      IndexOffset = indexOffset;
    }

  }
}

