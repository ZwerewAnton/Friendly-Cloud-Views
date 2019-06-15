using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPLOMA.Models
{
    public class DirectoryStatusRooms
    {
        public int DirectoryStatusRoomsID { get; set; }
        [Required]
        [StringLength(20)]
        public string StatusRoom { get; set; }

        public ICollection<DirectoryRooms> Rooms { get; set; }
    }
}
