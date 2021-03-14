namespace Shamrock.Systems
{
    public interface ISystem
    {
        /// <summary>
        /// `Init()` is run once by the <see cref="SystemManager"/> when the system is initialized
        /// </summary>
        void Init();

        /// <summary>
        /// `Tick()` is run every Unity Update
        /// </summary>
        void Tick(float deltaTime);

        /// <summary>
        /// `LateTick()` is run every Unity LateUpdate
        /// </summary>
        void LateTick(float deltaTime);

        /// <summary>
        /// `Destroy()` is run when the system is removed from the <see cref="SystemManager"/>
        /// </summary>
        void Destroy();
    }
}