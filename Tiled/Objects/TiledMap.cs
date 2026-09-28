using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using static MonoTile.SPTiledMap;

namespace MonoTile.Tiled
{
  public class TiledMap
  {
    public string Version { get; set; } = "";
    public string TiledVersion { get; set; } = "";

    public Orientation Orientation { get; set; }
    public RenderOrder RenderOrder { get; set; }

    public int CompressionLevel { get; set; }

    public int Width { get; set; }
    public int Height { get; set; }

    public int TileWidth { get; set; }
    public int TileHeight { get; set; }

    public bool Infinite { get; set; }

    public int NextLayerID { get; set; }
    public int NextObjectID { get; set; }

    public int ParallaxOriginX { get; set; }
    public int ParallaxOriginY { get; set; }

    public Color? BackgroundColor { get; set; }

    public IReadOnlyList<Tileset> Tilesets { get; set; }
      = Array.Empty<Tileset>();

    public IReadOnlyList<Layer> Layers { get; set; }
      = Array.Empty<Layer>();
  }

  public enum Orientation
  {
    Orthogonal,
    Isometric,
    Staggered,
    Hexagonal
  }

  public enum RenderOrder
  {
    RightDown,
    RightUp,
    LeftDown,
    LeftUp
  }
}
