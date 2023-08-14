using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public int TotalSolvedProblems { get; set; } = 0;
        public DateTime LastSubmession { get; set; }
        public int Points { get; set; }
        public string UserId { get; set; }
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public int CampId { get; set; }
        public Camp Camp { get; set; }
        public IEnumerable<TraineesAttendence> TraineesAttendences { get; set; }
        public IEnumerable<TraineeSheetAccess> TraineeSheetAccesses { get; set; }
        public IEnumerable<SessionFeedback> SessionFeedbacks { get; set; }

    }
}
