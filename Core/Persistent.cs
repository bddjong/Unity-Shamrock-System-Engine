using UnityEngine;

namespace Shamrock.Core
{
    public class Persistent : MonoBehaviour
    {
        public void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}