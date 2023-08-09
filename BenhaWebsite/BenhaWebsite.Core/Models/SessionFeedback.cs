using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class SessionFeedback
    {
        public string Feedback { get; set; }
        public DateTime Date { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }

    }
}
