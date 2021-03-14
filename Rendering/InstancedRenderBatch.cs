using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shamrock.Rendering
{
    /// <summary>
    /// Isolated InstancedRenderBatch struct that internally handles creating batches of 1023 matrices
    /// </summary>
    public readonly struct InstancedRenderBatch : IRenderer
    {
        private readonly List<List<Matrix4x4>> _matrices;
        private readonly Material _material;
        private readonly Mesh _mesh;

        public InstancedRenderBatch(Material material, Mesh mesh)
        {
            _material = material;
            _mesh = mesh;
            _matrices = new List<List<Matrix4x4>> {new List<Matrix4x4>()};
        }

        public void AddMatrix(Matrix4x4 matrix)
        {
            if (_matrices.Last().Count < 1023)
                _matrices.Last().Add(matrix);
            else
            {
                _matrices.Add(new List<Matrix4x4>());
                _matrices.Last().Add(matrix);
            }
        }

        public void AddMatrix(Vector3 pos)
        {
            AddMatrix(Matrix4x4.TRS(pos, Quaternion.identity, Vector3.one));
        }

        public void InitRenderer()
        {
        }

        public void Render()
        {
            foreach (List<Matrix4x4> matricesSubBatch in _matrices)
            {
                Graphics.DrawMeshInstanced(
                    _mesh,
                    0,
                    _material,
                    matricesSubBatch);
            }
        }
    }
}