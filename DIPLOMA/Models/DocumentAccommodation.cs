using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPLOMA.Models
{
    public class DocumentAccommodation
    {
        public int DocumentAccommodationID { get; set; }

        // Total information

        [Required]
        public int DirectoryStatusAccommodationID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-HH-mm}", ApplyFormatInEditMode = true)]
        public DateTime DateAccommodation { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-HH-mm}", ApplyFormatInEditMode = true)]
        public DateTime DateEviction { get; set; }
        [Required]
        public int NumberOfPersons { get; set; }

        // Date about Client

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [StringLength(4, MinimumLength = 4)]
        [RegularExpression(@"^[0-9]+$")]
        [Display(Name = "Серия паспорта")]
        public string PassportSerial { get; set; }
        [StringLength(6, MinimumLength = 6)]
        [RegularExpression(@"^[0-9]+$")]
        [Display(Name = "Номер паспорта")]
        public string PassportNumber { get; set; }
        [Display(Name = "Адрес регистрации")]
        public string AddressRegistration { get; set; }
        [Display(Name = "Адрес проживания")]
        public string AddressResidential { get; set; }
        [StringLength(11)]
        [RegularExpression(@"^[0-9]+$")]
        [Display(Name = "Телефон")]
        public string TelephoneNumber { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Данные о месте работы")]
        public string DataAboutWorkPlace { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата добавления")]
        public DateTime ClientDate { get; set; }

        // Date about Room

        [Required]
        public int DirectoryCategoryRoomsID { get; set; }
        [Required]
        public int DirectoryTypeRoomsID { get; set; }
        [Required]
        [StringLength(10)]
        public string NumberRoom { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal CostPerDay { get; set; }

        // Total information

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal CostTotal { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Payment { get; set; }

        public DirectoryStatusAccommodation DirectoryStatusBooking { get; set; }
        public DirectoryTypeRooms DirectoryTypeRooms { get; set; }
        public DirectoryCategoryRooms DirectoryCategoryRooms { get; set; }
    }
}
