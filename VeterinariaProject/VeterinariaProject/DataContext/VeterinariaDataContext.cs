using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinariaProject.Models;

namespace VeterinariaProject.DataContext
{
    public class VeterinariaDataContext : DbContext
    {
        public DbSet<Raza> Razas { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=DESKTOP-RM2NNQ3;DataBase=VeterinariaDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MascotaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
