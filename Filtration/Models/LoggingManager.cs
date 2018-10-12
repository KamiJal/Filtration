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
        private const string Format = "{{ userLogin = \"{0}\", sessionId = \"{1}\", exceptionName = \"{2}\", exceptionMessage = \"{3}\" }}";

        private readonly string _sessionId;
        private readonly string _userLogin;

        public LoggingManager()
        {
            var httpContext = HttpContext.Current;
            _sessionId = httpContext.Session.SessionID;
            _userLogin = httpContext.User.Identity.Name ?? String.Empty;
        }

        public void LogException(Exception exception)
        {
            //file logging
            var logger = LogManager.GetCurrentClassLogger();
            var message = String.Format(Format, _userLogin, _sessionId, exception.GetType().Name, exception.Message);
            logger.Error(message);

            //db logging
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var loggingException = new LoggingException(exception, _sessionId, _userLogin);
                    context.LoggingExceptions.Add(loggingException);
                    context.SaveChanges();
                }
            }
            catch (SqlException)
            {
                // ignored
            }
        }

        public void LogContactsVisitor()
        {
            //db logging
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var user = context.Users.SingleOrDefault(q => q.UserName.Equals(_userLogin));

                    var contactsVisitor = new LoggingContactsVisitor
                    {
                        SessionId = _sessionId,
                        UserLogin = _userLogin,
                        UserEmail = user?.Email ?? String.Empty,
                    };

                    context.LoggingContactsVisitors.Add(contactsVisitor);
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