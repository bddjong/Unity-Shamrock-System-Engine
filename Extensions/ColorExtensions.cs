using UnityEngine;

namespace BlueHarpGames.Shamrock.Extensions
{
    public static class ColorExtensions
    {
        public static Color WithAlpha(this Color color, float alphaValue)
        {
            color.a = alphaValue;
            return color;
        }
    }
}