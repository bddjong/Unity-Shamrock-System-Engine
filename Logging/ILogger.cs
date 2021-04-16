namespace BlueHarpGames.Shamrock.Logging
{
    public interface ILogger
    {
        void Message(string message);
        void Message(string message, object context);
        void Warning(string message);
        void Warning(string message, object context);
        void Error(string message);
        void Error(string message, object context);
    }
}