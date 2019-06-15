using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPLOMA.Models
{
    public class DirectoryServices
    {
        public int DirectoryServicesID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Служба")]
        public string Service { get; set; }

        public ICollection<DirectoryEmployees> Employees { get; set; }
    }
}
