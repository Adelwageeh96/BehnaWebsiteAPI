using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class Mentor
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IEnumerable<Trainee> Trainees { get; set; }
        public IEnumerable<MentorAttendence> mentorAttendences { get; set; }
        public IEnumerable<MentorOfCmap> MentorOfCmaps { get; set; }



    }
}
