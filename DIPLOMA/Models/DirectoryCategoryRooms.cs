using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPLOMA.Models
{
    public class DirectoryCategoryRooms
    {
        public int DirectoryCategoryRoomsID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Категория номеров")]
        public string CategoryRoom { get; set; }

        public ICollection<DirectoryRooms> Rooms { get; set; }
    }
}
