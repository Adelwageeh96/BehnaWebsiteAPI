using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class TraineesAttendence
    {
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
