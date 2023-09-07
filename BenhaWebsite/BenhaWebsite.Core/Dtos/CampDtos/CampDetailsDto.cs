using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Dtos.CampDtos
{
    public class CampDetailsDto
    {
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
        public int DurationInWeeks { get; set; }
        public string HeadOfCamp { get; set; }
        public int SheetsNumber { get; set; }
        public int TraineesNumber { get; set;}
    }
}
