namespace MonoTile
{
    public interface ITileLoader<T> where T : IMap
    {
        static abstract T Extract(string path);
    }
}