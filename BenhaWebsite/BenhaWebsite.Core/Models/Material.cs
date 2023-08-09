using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int SheetId { get; set; }
        public Sheet Sheet { get; set; }


    }
}
