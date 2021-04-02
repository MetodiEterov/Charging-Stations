namespace LoggerService
{
    using Entities.Contracts;
    using NLog;

    /// <summary>
    /// LoggerManager class
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// LogDebug method
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message)
        {
            Logger.Debug(message);
        }

        /// <summary>
        /// LogError method
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            Logger.Error(message);
        }

        /// <summary>
        /// LogInfo method
        /// </summary>
        /// <param name="message"></param>
        public void LogInfo(string message)
        {
            Logger.Info(message);
        }

        /// <summary>
        /// LogWarn method
        /// </summary>
        /// <param name="message"></param>
        public void LogWarn(string message)
        {
            Logger.Warn(message);
        }
    }
}
