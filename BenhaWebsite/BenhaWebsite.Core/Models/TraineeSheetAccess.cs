using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class TraineeSheetAccess
    {
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int sheetId { get; set; }
        public Sheet Sheet { get; set; }

        public int NumberOfProblems { get; set; }
    }
}
