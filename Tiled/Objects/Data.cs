namespace MonoTile.Tiled
{
  public enum DataEncoding
  {
    Csv,
    Base64
  }

  public enum DataCompression
  {
    GZip,
    ZLib,
    ZStd
  }

  public class Chunk
  {
    public required int X { get; set; }
    public required int Y { get; set; }

    public required int Width { get; set; }
    public required int Height { get; set; }

    public required uint[] GlobalTileIDs { get; set; }
  }

  public class Data
  {

  }
}
