using System;
using UnityEngine;

namespace Shamrock.Noise
{
    [Serializable]
    public struct NoiseData
    {
        [Range(0f, 40f)] public float Scale;
        [Range(0, 8)] public int Octaves;
        public float Persistance;
        public float Lacunarity;
        public float CircularExponentialFalloffRatio;
        public AnimationCurve NoiseFalloffCurve;
    }
}