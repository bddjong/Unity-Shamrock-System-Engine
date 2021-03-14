using Shamrock.Core;
using UnityEngine;

namespace Shamrock.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 ClampToBounds(this Vector3 value, Bounds bounds)
        {
            value.x = Mathf.Clamp(value.x, bounds.min.x, bounds.max.x);
            value.y = Mathf.Clamp(value.y, bounds.min.y, bounds.max.y);
            value.z = Mathf.Clamp(value.z, bounds.min.z, bounds.max.z);
            return value;
        }

        public static Vector2 AsVector2(this Vector3 value)
        {
            return new Vector2(value.x, value.y);
        }

        public static Vector2Int AsVector2Int(this Vector3 value, RoundingMode roundingMode)
        {
            return roundingMode == RoundingMode.Floor
                ? new Vector2Int(Mathf.FloorToInt(value.x), Mathf.FloorToInt(value.y))
                : new Vector2Int(Mathf.CeilToInt(value.x), Mathf.CeilToInt(value.y));
        }

        public static Vector2Int AsVector2Int3D(this Vector3 value, RoundingMode roundingMode)
        {
            return roundingMode == RoundingMode.Floor
                ? new Vector2Int(Mathf.FloorToInt(value.x), Mathf.FloorToInt(value.z))
                : new Vector2Int(Mathf.CeilToInt(value.x), Mathf.CeilToInt(value.z));
        }

        public static Vector3 Floored(this Vector3 value)
        {
            value.x = Mathf.Floor(value.x);
            value.y = Mathf.Floor(value.y);
            value.z = Mathf.Floor(value.z);
            return value;
        }

        public static Vector3 WithX(this Vector3 value, float x)
        {
            return new Vector3(value.x, value.y, x);
        }

        public static Vector3 WithY(this Vector3 value, float y)
        {
            return new Vector3(value.x, value.y, y);
        }

        public static Vector3 WithZ(this Vector3 value, float z)
        {
            return new Vector3(value.x, value.y, z);
        }
    }
}