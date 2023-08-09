using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class Camp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public int DurationInWeeks { get; set; }
        public IEnumerable<Trainee> Trainees { get; set; }
        public IEnumerable<Session> Sessions { get; set; }
        public IEnumerable<MentorOfCmap> MentorOfCmaps { get; set; }

    }
}
