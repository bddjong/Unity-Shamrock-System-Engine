using System;
using System.Collections.Generic;
using Shamrock.Logging;
using UnityEngine;

namespace Shamrock.Systems
{
    public class SystemManager
    {
        private readonly Dictionary<Type, ISystem> _systems;

        private static SystemManager Instance { get; set; }
        private static Dictionary<Type, ISystem> Systems => Instance._systems;

        public SystemManager(Dictionary<Type, ISystem> initialSystems)
        {
            Shamlogger.LogMessage("Initializing", this);
            if (Instance != null)
            {
                throw new UnityException("SystemManager has already been initialized.");
            }

            Instance = this;

            _systems = initialSystems;
            InitializeSystems();
        }

        public static void InitializeManager()
        {
            InitializeManager(new Dictionary<Type, ISystem>());
        }

        public static void InitializeManager(Dictionary<Type, ISystem> initialSystems)
        {
            new SystemManager(initialSystems);
        }

        public static T GetSystem<T>() where T : class, ISystem
        {
            return Systems[typeof(T)] as T;
        }

        public static void RegisterSystem<T>(T system) where T : class, ISystem
        {
            Systems.Add(typeof(T), system);
        }

        public static void DestroySystem<T>(T system) where T : class, ISystem
        {
            system.Destroy();
            Systems.Remove(typeof(T));
        }

        public static void RegisterSystemAndInitialize<T>(T system) where T : class, ISystem
        {
            Systems.Add(typeof(T), system);
            system.Init();
        }

        public static void InitializeSystems()
        {
            foreach (ISystem system in Systems.Values)
            {
                system.Init();
            }
        }

        public static void TickSystems()
        {
            float deltaTime = Time.deltaTime;
            foreach (ISystem system in Systems.Values)
            {
                system.Tick(deltaTime);
            }
        }

        public static void LateTickSystems()
        {
            float deltaTime = Time.deltaTime;
            foreach (ISystem system in Systems.Values)
            {
                system.LateTick(deltaTime);
            }
        }
    }
}