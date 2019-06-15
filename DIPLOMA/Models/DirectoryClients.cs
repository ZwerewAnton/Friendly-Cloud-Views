using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPLOMA.Models
{
    public class DirectoryClients
    {
        public int DirectoryClientsID { get; set; }
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
        [StringLength(11)]
        [RegularExpression(@"^[0-9]+$")]
        [Display(Name = "Телефон")]
        public string TelephoneNumber { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Данные о месте работы")]
        public string DataAboutWorkPlace { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата добавления")]
        public DateTime ClientDate { get; set; }
    }

    //migrationBuilder.CreateTable(
    //           name: "Clients",
    //            columns: table => new
    //            {
    //                DirectoryClientsID = table.Column<int>(nullable: false)
    //                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
    //                FirstName = table.Column<string>(maxLength: 50, nullable: false),
    //                SecondName = table.Column<string>(maxLength: 50, nullable: false),
    //                Patronymic = table.Column<string>(maxLength: 50, nullable: false),
    //                PassportSerial = table.Column<string>(maxLength: 4, nullable: false),
    //                PassportNumber = table.Column<string>(maxLength: 6, nullable: false),
    //                AddressRegistration = table.Column<string>(nullable: false),
    //                AddressResidential = table.Column<string>(nullable: false),
    //                TelephoneNumber = table.Column<string>(maxLength: 11, nullable: false),
    //                Email = table.Column<string>(nullable: false),
    //                DataAboutWorkPlace = table.Column<string>(nullable: false),
    //                ClientDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_Clients", x => x.DirectoryClientsID);
    //            });
}
