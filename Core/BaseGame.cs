using System;
using Shamrock.Logging;
using Shamrock.Rendering;
using Shamrock.Systems;
using UnityEngine;
using ILogger = Shamrock.Logging.ILogger;

namespace Shamrock.Core
{
    /// <summary>
    /// BaseGame class serves as the root of the game. Extend this object with a game implementation.
    /// </summary>
    /// <typeparam name="TGame">Extended BaseGame type</typeparam>
    /// <typeparam name="TLogger">Logger implementation type</typeparam>
    [DefaultExecutionOrder(-9999)]
    public abstract class BaseGame<TGame, TLogger> : SerializedSingletonMonoBehaviour<TGame>
        where TGame : BaseGame<TGame, TLogger>
        where TLogger : ILogger, new()
    {
        private ILogger _logger;
        private RenderManager _renderManager;

        protected new virtual void Awake()
        {
            base.Awake();
            _logger = new Shamlogger(new TLogger());
            _logger.Message("Initializing BaseGame", this);
            _renderManager = new RenderManager();
            InitializeSystemManager();
        }

        protected virtual void Update()
        {
            base.Awake();
            SystemManager.TickSystems();
            _renderManager.Render();
        }

        protected void LateUpdate()
        {
            SystemManager.LateTickSystems();
        }

        protected virtual void InitializeSystemManager()
        {
            SystemManager.InitializeManager();
        }
    }
}