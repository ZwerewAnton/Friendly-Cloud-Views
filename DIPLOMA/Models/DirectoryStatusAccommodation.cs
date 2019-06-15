using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPLOMA.Models
{
    public class DirectoryStatusAccommodation
    {
        public int DirectoryStatusAccommodationID { get; set; }
        [Required]
        [StringLength(20)]
        public string StatusAccommodation { get; set; }

        public ICollection<DocumentAccommodation> Accommodation { get; set; }
    }
}
