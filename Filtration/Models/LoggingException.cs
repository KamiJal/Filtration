using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace Filtration.Models
{
    public class LoggingException
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Message { get; set; }
        public string TargetSite { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public string SessionId { get; set; }
        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public LoggingException()
        {

        }

        public LoggingException(Exception exception, string sessionId, string userId)
        {
            Name = exception.GetType().Name;
            Message = exception.Message;
            TargetSite = exception.TargetSite.Name;
            StackTrace = exception.StackTrace;
            Source = exception.Source;
            CreatedDate = DateTime.Now;
            SessionId = sessionId;
            UserId = userId;
        }
    }
}