using System;
using UnityEngine;

namespace Shamrock.SerializableTypes
{
    [Serializable]
    public struct MinMaxFloat
    {
        [SerializeField] private float _min;
        [SerializeField] private float _max;

        public MinMaxFloat(float min, float max)
        {
            _min = min;
            _max = max;
        }

        public float Max => _max;
        public float Min => _min;
    }
}