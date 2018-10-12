using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using NLog;

namespace Filtration.Models
{
    public class LoggingManager
    {
        private const string Format = "{{ userId = \"{0}\", sessionId = \"{1}\", exceptionName = \"{2}\", exceptionMessage = \"{3}\" }}";

        public void LogException(Exception exception)
        {
            //request necessary data
            var httpContext= HttpContext.Current;
            var sessionId = httpContext.Session.SessionID;
            var userId = httpContext.User.Identity.Name ?? "";
         
            //file logging
            var logger = LogManager.GetCurrentClassLogger();
            var message = String.Format(Format, userId, sessionId, exception.GetType().Name, exception.Message);
            logger.Error(message);

            //db logging
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var loggingException = new LoggingException(exception, sessionId, userId);
                    context.LoggingExceptions.Add(loggingException);
                    context.SaveChanges();
                }
            }
            catch (SqlException)
            {
                // ignored
            }
        }

    }
}