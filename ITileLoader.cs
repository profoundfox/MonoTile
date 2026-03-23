namespace MonoTile
{
    public interface ITileLoader<T>
    {
        static abstract T Extract(string path);
    }
}