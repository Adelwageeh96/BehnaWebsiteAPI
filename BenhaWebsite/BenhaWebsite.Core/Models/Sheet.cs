using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class Sheet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfProblems { get; set; }
        public int SheetOrder { get; set; }
        public int? CampId { get; set; }
        public Camp? Camp { get; set; }
        public IEnumerable<Material> Materials { get; set; }
        public IEnumerable<TraineeSheetAccess> traineeSheetAccesses { get; set; }
    }
}
