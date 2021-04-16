using UnityEngine;

namespace BlueHarpGames.Shamrock.Core
{
    public class Persistent : MonoBehaviour
    {
        public void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}