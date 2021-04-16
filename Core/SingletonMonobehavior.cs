using UnityEngine;

namespace BlueHarpGames.Shamrock.Core
{
    [DefaultExecutionOrder(-1)]
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get => _instance == null ? InstantiateInstance() : _instance;
            set => _instance = value;
        }

        private static T InstantiateInstance()
        {
            _instance = new GameObject(typeof(T).FullName).AddComponent<T>();
            return _instance;
        }

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this);
            else
                _instance = this as T;
        }
    }
}