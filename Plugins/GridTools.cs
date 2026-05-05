namespace MonoTile
{
  public static class GridTools 
  {
      public static int[,] CloneGrid(this int[,] source)
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
  }
}
