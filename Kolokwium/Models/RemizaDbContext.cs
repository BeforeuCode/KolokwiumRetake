using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class RemizaDbContext : DbContext
    {

        public DbSet<Action> Actions { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<Firefighter> FireFigthers { get; set; }
        public DbSet<FirefighterAction> FirefighterActions { get; set; }
        public DbSet<FireTruckAction> FireTruckActions { get; set; }

        public RemizaDbContext() { }
        public RemizaDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Action>(mb =>
            {
                mb.HasKey(a => a.IdAction);
                mb.Property(a => a.IdAction).UseIdentityColumn();
                mb.Property(a => a.StartTime).IsRequired();
                mb.Property(a => a.EndTime);
                mb.Property(a => a.NeedForSpecialEquipment).IsRequired();

                mb.ToTable("Action");
            });

            modelBuilder.Entity<FireTruck>(mb =>
            {
                mb.HasKey(ft => ft.IdFireTruck);
                mb.Property(ft => ft.IdFireTruck).UseIdentityColumn();
                mb.Property(ft => ft.OperationalNumber).HasMaxLength(50).IsRequired();
                mb.Property(ft => ft.SpecialEquipement).IsRequired();

                mb.ToTable("FireTruck");
            });

            modelBuilder.Entity<Firefighter>(mb =>
            {
                mb.HasKey(ff => ff.IdFirefighter);
                mb.Property(ff => ff.IdFirefighter).UseIdentityColumn();
                mb.Property(ff => ff.FirstName).HasMaxLength(30).IsRequired();
                mb.Property(ff => ff.FirstName).HasMaxLength(50).IsRequired();

                mb.ToTable("Firefighter");
            });

            modelBuilder.Entity<FirefighterAction>(mb =>
            {
                mb.HasKey(ffa => new { ffa.IdFireFighter, ffa.IdAction });
                mb.HasIndex(ffa => ffa.IdFireFighter);
                mb.HasIndex(ffa => ffa.IdAction);

                mb.HasOne(ffa => ffa.Action)
                  .WithMany(a => a.FirefighterActions)
                  .HasForeignKey(ffa => ffa.IdAction);

                mb.HasOne(ffa => ffa.Firefighter)
                  .WithMany(ff => ff.FirefighterActions)
                  .HasForeignKey(ffa => ffa.IdFireFighter);


                mb.ToTable("Firefighter_Action");
            });


            modelBuilder.Entity<FireTruckAction>(mb =>
            {
                mb.HasKey(fta => fta.IdFireTruckAction);
                mb.Property(fta => fta.IdFireTruckAction).UseIdentityColumn();
                mb.Property(fta => fta.AssigmentDate).IsRequired();


                mb.HasIndex(fta => fta.IdFireTruck);
                mb.HasIndex(fta => fta.IdAction);

                mb.HasOne(fta => fta.Action)
                  .WithMany(a => a.FireTruckActions)
                  .HasForeignKey(fta => fta.IdAction);

                mb.HasOne(fta => fta.FireTruck)
                  .WithMany(ft => ft.FireTruckActions)
                  .HasForeignKey(fta => fta.IdFireTruck);


                mb.ToTable("FireTruckr_Action");
            });


        }
    }
}
