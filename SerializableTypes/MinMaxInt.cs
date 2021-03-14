using System;
using UnityEngine;

namespace Shamrock.SerializableTypes
{
    [Serializable]
    public struct MinMaxInt
    {
        [SerializeField] private int _min;
        [SerializeField] private int _max;

        public MinMaxInt(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public int Max => _max;
        public int Min => _min;
    }
}