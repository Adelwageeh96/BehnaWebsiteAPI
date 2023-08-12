using BenhaWebsite.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
    public class TraineeArchive : Archive
    {
        public string CmapName { get; set; }
        public bool IsCompleted { get; set; }
    }
}
