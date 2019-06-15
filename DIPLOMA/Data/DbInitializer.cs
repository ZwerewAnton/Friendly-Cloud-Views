using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIPLOMA.Models;

namespace DIPLOMA.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext_2 context)
        {
            context.Database.EnsureCreated();

            if (context.StatusAccommodation.Any())
            {
                return;   // DB has been seeded
            }

            var statusAccommodation = new DirectoryStatusAccommodation[]
            {
            new DirectoryStatusAccommodation{StatusAccommodation="Бронирование"},
            new DirectoryStatusAccommodation{StatusAccommodation="Заселение"},
            new DirectoryStatusAccommodation{StatusAccommodation="Выселение"},
            new DirectoryStatusAccommodation{StatusAccommodation="Отмена"}
            };
            foreach (DirectoryStatusAccommodation s in statusAccommodation)
            {
                context.StatusAccommodation.Add(s);
            }
            context.SaveChanges();


            if (context.StatusRooms.Any())
            {
                return;   // DB has been seeded
            }

            var statusRooms = new DirectoryStatusRooms[]
            {
            new DirectoryStatusRooms{StatusRoom="Свободен"},
            new DirectoryStatusRooms{StatusRoom="Занят"},
            new DirectoryStatusRooms{StatusRoom="Ремонт"}
            };
            foreach (DirectoryStatusRooms s in statusRooms)
            {
                context.StatusRooms.Add(s);
            }
            context.SaveChanges();

            if (context.CategoryRooms.Any())
            {
                return;   // DB has been seeded
            }

            var categoryRooms = new DirectoryCategoryRooms[]
            {
            new DirectoryCategoryRooms{CategoryRoom="Standart"},
            new DirectoryCategoryRooms{CategoryRoom="Apartment"},
            new DirectoryCategoryRooms{CategoryRoom="De luxe"},
            new DirectoryCategoryRooms{CategoryRoom="Family Room"},
            };
            foreach (DirectoryCategoryRooms s in categoryRooms)
            {
                context.CategoryRooms.Add(s);
            }
            context.SaveChanges();


            if (context.TypeRooms.Any())
            {
                return;   // DB has been seeded
            }

            var typeRooms = new DirectoryTypeRooms[]
            {
            new DirectoryTypeRooms{TypeRoom="1-местный"},
            new DirectoryTypeRooms{TypeRoom="2-местный"},
            new DirectoryTypeRooms{TypeRoom="3-местный"},
            new DirectoryTypeRooms{TypeRoom="4-местный"},
            };
            foreach (DirectoryTypeRooms s in typeRooms)
            {
                context.TypeRooms.Add(s);
            }
            context.SaveChanges();


            if (context.Rooms.Any())
            {
                return;   // DB has been seeded
            }

            var rooms = new DirectoryRooms[]
            {
            new DirectoryRooms{DirectoryCategoryRoomsID = categoryRooms.Single( i => i.CategoryRoom == "De luxe").DirectoryCategoryRoomsID,
                               DirectoryTypeRoomsID = typeRooms.Single( i => i.TypeRoom == "1-местный").DirectoryTypeRoomsID, NumberRoom ="1",
                               DirectoryStatusRoomsID = statusRooms.Single( i => i.StatusRoom == "Свободен").DirectoryStatusRoomsID, CostPerDay = 1000},
            new DirectoryRooms{DirectoryCategoryRoomsID = categoryRooms.Single( i => i.CategoryRoom == "Apartment").DirectoryCategoryRoomsID,
                               DirectoryTypeRoomsID = typeRooms.Single( i => i.TypeRoom == "2-местный").DirectoryTypeRoomsID, NumberRoom ="2",
                               DirectoryStatusRoomsID = statusRooms.Single( i => i.StatusRoom == "Свободен").DirectoryStatusRoomsID, CostPerDay = 800},
            new DirectoryRooms{DirectoryCategoryRoomsID = categoryRooms.Single( i => i.CategoryRoom == "Family Room").DirectoryCategoryRoomsID,
                               DirectoryTypeRoomsID = typeRooms.Single( i => i.TypeRoom == "3-местный").DirectoryTypeRoomsID, NumberRoom ="3",
                               DirectoryStatusRoomsID = statusRooms.Single( i => i.StatusRoom == "Свободен").DirectoryStatusRoomsID, CostPerDay = 900},
            new DirectoryRooms{DirectoryCategoryRoomsID = categoryRooms.Single( i => i.CategoryRoom == "Standart").DirectoryCategoryRoomsID,
                               DirectoryTypeRoomsID = typeRooms.Single( i => i.TypeRoom == "4-местный").DirectoryTypeRoomsID, NumberRoom ="4",
                               DirectoryStatusRoomsID = statusRooms.Single( i => i.StatusRoom == "Свободен").DirectoryStatusRoomsID, CostPerDay = 700},
            };
            foreach (DirectoryRooms s in rooms)
            {
                context.Rooms.Add(s);
            }
            context.SaveChanges();

            // Look for any Services.
            if (context.Services.Any())
            {
                return;   // DB has been seeded
            }

            var services = new DirectoryServices[]
            {
            new DirectoryServices{Service="Администратор"},
            new DirectoryServices{Service="Уборщик"}
            };
            foreach (DirectoryServices s in services)
            {
                context.Services.Add(s);
            }
            context.SaveChanges();


            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new DirectoryEmployees[]
            {
            new DirectoryEmployees{FirstName="Георгий",SecondName="Васильев",Patronymic="Петрович",PassportSerial="0110",PassportNumber="213432",
                                AddressRegistration="г.Красноярск, ул.Пушкина, д.12/1, Индекс:454324",AddressResidential="г.Красноярск, ул.Пушкина, д.12/1, Индекс:454324",
                                MaritalStatus = true, TelephoneNumber="89732114323", Education="КГУ(ФИТ), бакалавр", Email ="georgvas@mail.ru",
                                DirectoryServicesID = services.Single( i => i.Service == "Администратор").DirectoryServicesID, EmployeeDate=Convert.ToDateTime("01.02.2019")},
            new DirectoryEmployees{FirstName="Екатерина",SecondName="Рудова",Patronymic="Романовна",PassportSerial="0110",PassportNumber="122143",
                                AddressRegistration="г.Красноярск, ул.Георгиева, д.1/21, Индекс:124359",AddressResidential="г.Красноярск, ул.Георгиева, д.1/21, Индекс:124359",
                                MaritalStatus = true, TelephoneNumber="89863456743", Education="КГУ(ХБФ), бакалавр", Email ="ekaterrud@mail.ru",
                                DirectoryServicesID = services.Single( i => i.Service == "Уборщик").DirectoryServicesID, EmployeeDate=Convert.ToDateTime("01.02.2019")}
            };
            foreach (DirectoryEmployees s in employees)
            {
                context.Employees.Add(s);
            }
            context.SaveChanges();


            if (context.Clients.Any())
            {
                return;   // DB has been seeded
            }

            var clients = new DirectoryClients[]
            {
            new DirectoryClients{FirstName="Александр",SecondName="Петров",Patronymic="Иванович",PassportSerial="0110",PassportNumber="111111",
                                AddressRegistration="г.Красноярск, ул.Ленинна, д.34/23, Индекс:412432",AddressResidential="г.Красноярск, ул.Ленинна, д.34/23, Индекс:412432",
                                TelephoneNumber="89823425634",Email="alexbge@mail.ru",DataAboutWorkPlace="Строитель, ООО\"Стройпласт\"",ClientDate=Convert.ToDateTime("12.05.2019")}
            };
            foreach (DirectoryClients s in clients)
            {
                context.Clients.Add(s);
            }
            context.SaveChanges();

        }
    }
}
