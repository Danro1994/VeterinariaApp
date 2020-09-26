using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinariaProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VeterinariaProject.DataContext
{
    public class MascotaMap : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable("Mascotas", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.Nombre).HasColumnType("varchar(50)")
                .HasMaxLength(50).IsRequired();

            builder.HasOne(e => e.Raza)
                .WithMany(e => e.Mascotas)
                .HasForeignKey(e => e.RazaId);
            
        }
    }
}
