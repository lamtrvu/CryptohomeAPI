using CryptohomeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptohomeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
