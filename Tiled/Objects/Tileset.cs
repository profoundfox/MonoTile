namespace MonoTile.Tiled
{
  public enum ObjectAlignment
  {
    TopLeft, Top, TopRight,
    Left, Center, Right,
    BottomLeft, Bottom, BottomRight,
    Unspecified
  }

  public enum TileRenderSize
  {
    Grid,
    Tile
  }

  public enum FillMode
  {
    PreserveAspectFit,
    Stretch
  }

  public class Tileset
  {
    public int FirstGiD { get; set; }

    public string Name { get; set; } = "";
    public string Class { get; set; } = "";

    public int TileWidth { get; set; }
    public int TileHeight { get; set; }

    public int Spacing { get; set; }
    public int Margin { get; set; }

    public int TileCount { get; set; }
    public int Columns { get; set; }

    public ObjectAlignment Alignment { get; set; }
    public TileRenderSize RenderSize { get; set; }
    public FillMode Mode { get; set; }



  }
}
