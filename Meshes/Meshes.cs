using Microsoft.Win32.SafeHandles;
using UnityEngine;

namespace Shamrock.Meshes
{
    public static class MeshCreator
    {
        public static Mesh Quad(float width, float height, Vector2 origin)
        {
            Vector3[] vertices = new Vector3[4]
            {
                new Vector3(0 - origin.x, 0 + origin.y, 0),
                new Vector3(width - origin.x, 0 + origin.y, 0),
                new Vector3(0 - origin.x, height + origin.y, 0),
                new Vector3(width - origin.x, height + origin.y, 0)
            };

            int[] tris = new int[6]
            {
                0, 2, 1,
                2, 3, 1
            };

            Vector2[] uv = new Vector2[4]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(0, 1),
                new Vector2(1, 1)
            };

            Mesh mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = tris;
            mesh.uv = uv;
            mesh.RecalculateNormals();
            return mesh;
        }
    }
}