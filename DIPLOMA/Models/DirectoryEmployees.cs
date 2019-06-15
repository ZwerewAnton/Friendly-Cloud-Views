using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPLOMA.Models
{
    public class DirectoryEmployees
    {
        public int DirectoryEmployeesID { get; set; }
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
        [Required]
        [StringLength(4, MinimumLength = 4)]
        [RegularExpression(@"^[0-9]+$")]
        [Display(Name = "Серия паспорта")]
        public string PassportSerial { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6)]
        [RegularExpression(@"^[0-9]+$")]
        [Display(Name = "Номер паспорта")]
        public string PassportNumber { get; set; }
        [Required]
        [Display(Name = "Адрес регистрации")]
        public string AddressRegistration { get; set; }
        [Required]
        [Display(Name = "Адрес проживания")]
        public string AddressResidential { get; set; }
        [Required]
        [Display(Name = "Женат(замужем)")]
        public bool MaritalStatus { get; set; }
        [Required]
        [StringLength(11)]
        [RegularExpression(@"^[0-9]+$")]
        [Display(Name = "Телефон")]
        public string TelephoneNumber { get; set; }
        [Required]
        [Display(Name = "Образование")]
        public string Education { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Служба")]
        public int DirectoryServicesID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата добавления")]
        public DateTime EmployeeDate { get; set; }

        public DirectoryServices DirectoryServices { get; set; }
    }
}
