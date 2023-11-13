using Microsoft.EntityFrameworkCore;
using Trucking.Entities;

namespace Trucking.Context
{
    public class Context : DbContext
    {
        public DbSet<Trucker> Truckers { get; set; }

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
            base.OnModelCreating(modelBuilder);
        }
    }
}
