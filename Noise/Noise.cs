using UnityEngine;
using Random = System.Random;

namespace BlueHarpGames.Shamrock.Noise
{
    public static class Noise
    {
        private static float PerlinNoise(float x, float y)
        {
            return Mathf.PerlinNoise(x, y);
        }

        public static float[,] PerlinNoiseMap(int width, int height, NoiseData noiseData, string seed)
        {
            Random random = new Random(seed.GetHashCode());
            Vector2[] octaveOffsets = new Vector2[noiseData.Octaves];
            for (int i = 0; i < octaveOffsets.Length; i++)
            {
                // Generate the random offsets for each octave.
                // Limited to a range of 160.000 as Mathf.PerlinNoise has strange behaviour if the x or y is too large
                octaveOffsets[i] = new Vector2(
                    random.Next(-80000, 80000),
                    random.Next(-80000, 80000)
                );
            }

            float[,] noiseMap = new float[width, height];
            noiseData.Scale = Mathf.Max(noiseData.Scale, 0.001f);

            float maxNoiseHeight = float.MinValue;
            float minNoiseHeight = float.MaxValue;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float amplitude = 1f;
                    float frequency = 1f;
                    float noiseHeight = 0f;

                    for (int i = 0; i < noiseData.Octaves; i++)
                    {
                        float sampleX = x / noiseData.Scale * frequency + octaveOffsets[i].x;
                        float sampleY = y / noiseData.Scale * frequency + octaveOffsets[i].y;

                        float perlinValue = PerlinNoise(sampleX, sampleY) * 2 - 1;
                        noiseHeight += perlinValue * amplitude;
                        amplitude *= noiseData.Persistance;
                        frequency *= noiseData.Lacunarity;
                    }

                    maxNoiseHeight = Mathf.Max(maxNoiseHeight, noiseHeight);
                    minNoiseHeight = Mathf.Min(minNoiseHeight, noiseHeight);

                    noiseMap[x, y] = noiseHeight;
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
                }
            }

            return noiseMap;
        }
    }
}