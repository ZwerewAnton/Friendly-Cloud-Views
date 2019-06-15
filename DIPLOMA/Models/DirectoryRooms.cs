using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPLOMA.Models
{
    public class DirectoryRooms
    {
        public int DirectoryRoomsID { get; set; }
        [Required]
        [Display(Name = "Категория")]
        public int DirectoryCategoryRoomsID { get; set; }
        [Required]
        [Display(Name = "Тип")]
        public int DirectoryTypeRoomsID { get; set; }
        [Required]
        [Display(Name = "Статус")]
        public int DirectoryStatusRoomsID { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Стоимость за день")]
        [Column(TypeName = "money")]
        public decimal CostPerDay { get; set; }
        [Required]
        [Display(Name = "Номер комнаты")]
        [StringLength(10)]
        public string NumberRoom { get; set; }

        public DirectoryTypeRooms DirectoryTypeRooms { get; set; }
        public DirectoryCategoryRooms DirectoryCategoryRooms { get; set; }
        public DirectoryStatusRooms DirectoryStatusRooms { get; set; }
    }
}
