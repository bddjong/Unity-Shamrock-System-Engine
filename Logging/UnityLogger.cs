using UnityEngine;

namespace Shamrock.Logging
{
    public class UnityLogger : ILogger
    {
        public void Message(string message)
        {
            Debug.Log(message);
        }

        public void Message(string message, object context)
        {
            Debug.Log($"{context.GetType().Name} -- {message}");
        }

        public void Warning(string message)
        {
            Debug.LogWarning(message);
        }

        public void Warning(string message, object context)
        {
            Debug.LogWarning($"{context.GetType().Name} -- {message}");
        }

        public void Error(string message)
        {
            Debug.LogError(message);
        }

        public void Error(string message, object context)
        {
            Debug.LogError($"{context.GetType().Name} -- {message}");
        }
    }
}