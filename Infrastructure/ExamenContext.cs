using ApplicationCore.Domain;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ExamenContext:DbContext
    {
        public DbSet<Activite> Activites { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Conseiller> Conseillers { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Data Source=(localdb)\mssqllocaldb;
                   Initial Catalog=AgenceTwin;
                   Integrated Security=true;
                   MultipleActiveResultSets=true");
            //Activer LazyLoading
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        //OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Type détenu
            modelBuilder.Entity<Activite>().OwnsOne(a => a.Zone);
            //Configurer la porteuse de données
            modelBuilder.Entity<Reservation>()
                        .HasKey(r => new { r.PackFk, r.ClientFk, r.DateReservation });
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        //ConfigureConventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(100);

            base.ConfigureConventions(configurationBuilder);
        }

    }
}
