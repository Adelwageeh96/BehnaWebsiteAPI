using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class MentorOfCmap
    {
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public int CampId { get; set; }
        public Camp Camp { get; set; }


    }
}
