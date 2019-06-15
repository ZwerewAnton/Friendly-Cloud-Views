using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPLOMA.Models
{
    public class DirectoryTypeRooms
    {
        public int DirectoryTypeRoomsID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Вид номера")]
        public string TypeRoom { get; set; }

        public ICollection<DirectoryRooms> Rooms { get; set; }
    }
}
