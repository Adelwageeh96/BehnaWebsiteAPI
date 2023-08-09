using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class MentorAttendence
    {
        public int MentorId { get; set; }   
        public Mentor Mentor { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }

    }
}
