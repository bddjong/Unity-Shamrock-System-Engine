using BlueHarpGames.Shamrock.Systems;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BlueHarpGames.Shamrock.Core
{
    [DefaultExecutionOrder(-1)]
    public abstract class SerializedSingletonMonoBehaviour<T> : SerializedMonoBehaviour where T : Component
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

        public virtual void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this);
            else
                _instance = this as T;
        }

        protected TSystem GetSystem<TSystem>() where TSystem : class, ISystem
        {
            return SystemManager.GetSystem<TSystem>();
        }
    }
}