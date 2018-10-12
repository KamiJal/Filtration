using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace Filtration.Models
{
    public class LoggingContactsVisitor
    {
        public int Id { get; set; }

        [Display(Name = "Session Id")]
        public string SessionId { get; set; }

        [Display(Name = "Login")]
        public string UserLogin { get; set; }

        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        [Display(Name = "Visited Date")]
        public DateTime VisitedDate { get; set; }

        public LoggingContactsVisitor()
        {
            VisitedDate = DateTime.Now;
        }
    }
}