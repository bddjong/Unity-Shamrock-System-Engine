namespace Shamrock.Extensions
{
    public static class ArrayExtensions
    {
        public static void PopulateWithDefaultConstructor<T>(this T[,] array) where T : class, new()
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    array[x, y] = new T();
                }
            }
        }
    }
}