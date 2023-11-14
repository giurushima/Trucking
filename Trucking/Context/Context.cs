using Microsoft.EntityFrameworkCore;
using Trucking.Entities;
using Trucking.Enums;

namespace Trucking.Context
{
    public class Context : DbContext
    {
        public DbSet<Trucker> Truckers { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var truckers = new Trucker[3]
            {

                new Trucker()
                {
                    Id = 1,
                    CompleteName = "Juan Gomez",
                    TruckerType = "Carga Seca",
                },
                new Trucker()
                {
                    Id = 2,
                    CompleteName = "Martin Suarez",
                    TruckerType = "Autos",

                },
                new Trucker()
                {
                    Id = 3,
                    CompleteName = "Agustin Ramirez",
                    TruckerType = "Ganaderia",

                }
            };
            modelBuilder.Entity<Trucker>().HasData(truckers);

            var trips = new Trip[3]
            {

                new Trip()
                {
                    Id = 1,
                    Source = "Rosario, Santa Fe",
                    Destiny = "CABA, Buenos Aires",
                    Description = "Viaje de ...",
                    TripStatus = TripStatus.Pending,
                },
                new Trip()
                {
                    Id = 1,
                    Source = "Arroyo Seco, Buenos Aires",
                    Destiny = "Bariloche, Rio Negro",
                    Description = "Viaje de ...",
                    TripStatus = TripStatus.InProgress,

                },
                new Trip()
                {
                    Id = 1,
                    Source = "Rosario, Santa Fe",
                    Destiny = "Carlos Paz, Cordoba",
                    Description = "Viaje de ...",
                    TripStatus = TripStatus.Complete,
                }
            };

            modelBuilder.Entity<Trip>().HasData(trips);

            base.OnModelCreating(modelBuilder);
        }
    }
}

