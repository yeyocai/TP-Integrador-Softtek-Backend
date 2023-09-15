using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TP_Integrador_Softtek_Backend.Entities;

namespace TP_Integrador_Softtek_Backend.DataAccess.DatabaseSeeding
{
    public class WorkSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Work>().HasData(
                
                new Work
                {
                    Id = 10500,
                    Date = new DateTime(2023,5,15),
                    ProjectId = 10,
                    ServiceId = 1,
                    NumberOfHours = 9,
                    HourValue = 5030.25,
                    Cost = 45272.25,
                    DischargeDate = null
                },

                new Work
                {
                    Id = 13400,
                    Date = new DateTime(2023, 8, 26),
                    ProjectId = 30,
                    ServiceId = 2,
                    NumberOfHours = 12,
                    HourValue = 4500.30,
                    Cost = 54003.60,
                    DischargeDate = null
                });
        }
    }
}
