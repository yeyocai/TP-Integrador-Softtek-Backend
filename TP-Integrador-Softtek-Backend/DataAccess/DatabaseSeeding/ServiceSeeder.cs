using Microsoft.EntityFrameworkCore;
using TP_Integrador_Softtek_Backend.Entities;

namespace TP_Integrador_Softtek_Backend.DataAccess.DatabaseSeeding
{
    public class ServiceSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(

                new Service
                {
                    Id = 1,
                    Description = "Servicio de soldadura de caños",
                    State = true,
                    HourValue = 25700.25
                },

                new Service
                {
                    Id = 2,
                    Description = "Servicio de instalación de gasoducto",
                    State = true,
                    HourValue = 35800.70
                },

                new Service
                {
                    Id = 3,
                    Description = "Servicio de sellado de pérdidas",
                    State = false,
                    HourValue = 10500.90
                });
        }
    }
}
