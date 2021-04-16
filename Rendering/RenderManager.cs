using System.Collections.Generic;
using BlueHarpGames.Shamrock.Core;
using BlueHarpGames.Shamrock.Logging;
using Sirenix.Utilities;

namespace BlueHarpGames.Shamrock.Rendering
{
    public class RenderManager : Singleton<RenderManager>
    {
        private readonly HashSet<IRenderer> _renderers;

        public RenderManager()
        {
            Shamlogger.LogMessage("Initializing", this);
            _renderers = new HashSet<IRenderer>();
        }

        public void RegisterRenderer(IRenderer renderer)
        {
            Shamlogger.LogMessage($"Registered renderer: {renderer.GetType().Name}", this);
            _renderers.Add(renderer);
            renderer.InitRenderer();
        }

        public void RemoveRenderer(IRenderer renderer)
        {
            Shamlogger.LogMessage($"Removed renderer: {renderer.GetType().Name}", this);
            _renderers.Remove(renderer);
        }

        public void RemoveRendererIfExists(IRenderer renderer)
        {
            if(_renderers.Contains(renderer))
                RemoveRenderer(renderer);
        }

        public void Render()
        {
            _renderers.ForEach(renderer => renderer.Render());
        }
        
        public static void Register(IRenderer renderer) => Instance.RegisterRenderer(renderer);
        public static void Remove(IRenderer renderer) => Instance.RemoveRenderer(renderer);
        public static void RemoveIfExists(IRenderer renderer) => Instance.RemoveRendererIfExists(renderer);
    }
}