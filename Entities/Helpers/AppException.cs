namespace Entities.Helpers
{
    using System;
    using System.Globalization;

    /// <summary>
    /// AppException class
    /// </summary>
    public class AppException : Exception
    {
        /// <summary>
        /// AppException constructor
        /// </summary>
        public AppException() : base() { }

        /// <summary>
        /// AppException constructor
        /// </summary>
        /// <param name="message"></param>
        public AppException(string message) : base(message) { }

        /// <summary>
        /// AppException constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public AppException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
