using UnityEngine;

namespace Shamrock.Core
{
    [DefaultExecutionOrder(-1)]
    public abstract class Singleton<T> where T : class, new()
    {
        private static T _instance;

        protected Singleton()
        {
            _instance = this as T;
        }


        public static T Instance
        {
            get => _instance ?? InstantiateInstance();
            set => _instance = value;
        }

        private static T InstantiateInstance()
        {
            _instance = new T();
            return _instance;
        }
    }
}