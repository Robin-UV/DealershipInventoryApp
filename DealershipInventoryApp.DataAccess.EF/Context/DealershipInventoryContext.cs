using System;
using DealershipInventoryApp.DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DealershipInventoryApp.DataAccess.EF.Context
{
	public partial class DealershipInventoryContext : DbContext 
	{
		public DealershipInventoryContext()
		{

		}

		public DealershipInventoryContext(DbContextOptions<DealershipInventoryContext> options)
			:base(options)
		{

		}

		public virtual DbSet<DealershipInventory> DealershipInventory { get; set; } = null!; 

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DealershipInventory>(entity =>
			{
				entity.HasKey(e => e.VehicleId);

				entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

				entity.Property(e => e.Make)
					.IsRequired()
					.HasMaxLength(255);

				entity.Property(e => e.Model)
					.IsRequired()
					.HasMaxLength(255);

				entity.Property(e => e.BodyType)
					.IsRequired()
					.HasMaxLength(255);

				entity.Property(e => e.TrimLevel)
					.IsRequired()
					.HasMaxLength(255);

				entity.Property(e => e.Year).HasColumnName("Year");

				entity.Property(e => e.Miles).HasColumnName("Miles");

				entity.Property(e => e.Price).HasColumnType("decimal(14,2)"); 
			});

            OnModelCreatingPartial(modelBuilder);
        }

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder); 
	}
}

