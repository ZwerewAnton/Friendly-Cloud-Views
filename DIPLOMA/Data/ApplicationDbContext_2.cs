using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIPLOMA.Models;
using Microsoft.EntityFrameworkCore;

namespace DIPLOMA.Data
{
    public class ApplicationDbContext_2 : DbContext
    {
        public ApplicationDbContext_2(DbContextOptions<ApplicationDbContext_2> options) : base(options)
        {
        }

        public DbSet<DirectoryClients> Clients { get; set; }
        public DbSet<DirectoryEmployees> Employees { get; set; }
        public DbSet<DirectoryServices> Services { get; set; }
        public DbSet<DirectoryCategoryRooms> CategoryRooms { get; set; }
        public DbSet<DirectoryTypeRooms> TypeRooms { get; set; }
        public DbSet<DirectoryRooms> Rooms { get; set; }
        public DbSet<DirectoryStatusRooms> StatusRooms { get; set; }

        public DbSet<DirectoryStatusAccommodation> StatusAccommodation { get; set; }
        public DbSet<DocumentAccommodation> Accommodation { get; set; }
    }
}
