using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Dtos.CampDtos
{
    public class CampAddEditDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInWeeks { get; set; }
        public int HeadOfCampId { get; set; }

    }
}
