using BlueHarpGames.Shamrock.Logging;

namespace BlueHarpGames.Shamrock.Systems
{
    public abstract class BaseSystem : ISystem
    {
        public virtual void Init()
        {
            Shamlogger.LogMessage($"Initializing", this);
        }

        public virtual void Tick(float deltaTime)
        {
        }

        public virtual void LateTick(float deltaTime)
        {
        }

        public virtual void Destroy()
        {
            Shamlogger.LogMessage("Destroying", this);
        }
    }
}