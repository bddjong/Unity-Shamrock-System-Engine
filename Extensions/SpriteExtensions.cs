using UnityEngine;

namespace Shamrock.Extensions
{
    public static class SpriteExtensions
    {
        public static Vector2[] TrivectorUVs(this Sprite sprite)
        {
            return new Vector2[4]
            {
                sprite.uv[3],
                sprite.uv[1],
                sprite.uv[0],
                sprite.uv[2],
            };
        }
    }
}