using Microsoft.EntityFrameworkCore;
using Trucking.Entities;
using Trucking.Enums;

namespace Trucking.Context
{
    public class TruckContext : DbContext
    {
        public DbSet<Trucker> Truckers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }

        public TruckContext(DbContextOptions<TruckContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
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
                    TruckerId = truckers[0].Id,
                },
                new Trip()
                {
                    Id = 2,
                    Source = "Arroyo Seco, Buenos Aires",
                    Destiny = "Bariloche, Rio Negro",
                    Description = "Viaje de ...",
                    TripStatus = TripStatus.InProgress,
                    TruckerId = truckers[0].Id,
                },
                new Trip()
                {
                    Id = 3,
                    Source = "Rosario, Santa Fe",
                    Destiny = "Carlos Paz, Cordoba",
                    Description = "Viaje de ...",
                    TripStatus = TripStatus.Complete,
                    TruckerId = truckers[1].Id,
                }
            };
            modelBuilder.Entity<Trip>().HasData(trips);

            var users = new User[3]
            {
                new User()
                {
                    Id = 7,
                    Name = "Gabriel",
                    UserName = "gabriel",
                    Password = "1234",
                },
                new User()
                {
                    Id = 7,
                    Name = "Fernando",
                    UserName = "fernando",
                    Password = "1234",
                },
                new User()
                {
                    Id = 7,
                    Name = "Sara",
                    UserName = "sara",
                    Password = "1234",
                }
            };

            modelBuilder.Entity<User>().HasData(users);

            base.OnModelCreating(modelBuilder);
        }
    }
}

