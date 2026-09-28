using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoTile.Tiled
{
  public abstract class Layer
  {
    public int Id { get; init; }
    public string Name { get; init; }

    public float Opacity { get; init; } = 1f;
    public bool Visible { get; init; } = true;

    public float OffsetX { get; init; }
    public float OffsetY { get; init; }

    public float ParallaxX { get; init; }
    public float ParallaxY { get; init; }

    public Color TintColor { get; init; }

    public Dictionary<string, object> Properties { get; init; }
  }

  public abstract class ObjectLayer : Layer
  {
    public List<Object> Objects { get; init; }
  }
}
