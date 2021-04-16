using System;
using UnityEngine;

namespace BlueHarpGames.Shamrock.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 ClampToBounds(this Vector2 value, Bounds bounds)
        {
            value.x = Mathf.Clamp(value.x, bounds.min.x, bounds.max.x);
            value.y = Mathf.Clamp(value.y, bounds.min.y, bounds.max.y);
            return value;
        }

        public static Vector3 AsVector3(this Vector2 value, float z)
        {
            return new Vector3(value.x, value.y, z);
        }

        public static Vector2 Floored(this Vector2 value)
        {
            value.x = Mathf.Floor(value.x);
            value.y = Mathf.Floor(value.y);
            return value;
        }

        public static Vector2Int ToIsometricGridPosition(this Vector2 value, Vector2 gridOrigin, float cellWidth)
        {
            throw new NotImplementedException("ToIsometricGridPosition has not yet been implemented");
        }
    }
}