using UnityEngine;

namespace Shamrock.Extensions
{
    public static class Vector2IntExtensions
    {
        public static int Product(this Vector2Int value) => value.x * value.y;
    }
}