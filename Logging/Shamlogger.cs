using Shamrock.Core;

namespace Shamrock.Logging
{
    public class Shamlogger : Singleton<Shamlogger>, ILogger
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Default constructor creates an instance of the default logger ('UnityLogger')
        /// </summary>
        public Shamlogger()
        {
            _logger = new UnityLogger();
        }

        public Shamlogger(ILogger loggerImplementation)
        {
            _logger = loggerImplementation;
        }

        public static void LogMessage(string message) => Instance.Message(message);
        public static void LogMessage(string message, object context) => Instance.Message(message, context);
        public static void LogWarning(string message) => Instance.Warning(message);
        public static void LogWarning(string message, object context) => Instance.Warning(message, context);
        public static void LogError(string message) => Instance.Error(message);
        public static void LogError(string message, object context) => Instance.Error(message, context);

        public void Message(string message)
        {
            _logger.Message(message);
        }

        public void Message(string message, object context)
        {
            _logger.Message(message, context);
        }

        public void Warning(string message)
        {
            _logger.Warning(message);
        }

        public void Warning(string message, object context)
        {
            _logger.Warning(message, context);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(string message, object context)
        {
            _logger.Error(message, context);
        }
    }
}