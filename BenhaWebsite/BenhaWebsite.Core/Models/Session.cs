using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string InstructorName { get; set; }
        public DateTime Date { get; set; }
        public string LocationName { get; set; }
        public string LocationLink { get; set; }
        public int CampId { get; set; }
        public Camp Camp { get; set; }
        public IEnumerable<TraineesAttendence> TraineesAttendences { get; set; }
        public IEnumerable<SessionFeedback> SessionFeedbacks { get; set; }
        public IEnumerable<MentorAttendence> MentorAttendences { get; set; }

    }
}
