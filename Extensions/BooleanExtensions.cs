namespace Shamrock.Extensions
{
    public static class BooleanExtensions
    {
        public static int ToInt(this bool v)
        {
            return v ? 1 : 0;
        }
    }
}