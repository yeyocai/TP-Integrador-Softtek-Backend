using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TP_Integrador_Softtek_Backend.Entities;

namespace TP_Integrador_Softtek_Backend.DataAccess.DatabaseSeeding
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(

                new User
                {
                    Id = 1010,
                    Name = "Juan Perez",
                    Dni = 11222333,
                    Type = User.UserType.Administrador,
                    Password = "1234",
                    DischargeDate = null
                },

                new User
                {
                    Id = 2020,
                    Name = "Maria Lopez",
                    Dni = 22111555,
                    Type = User.UserType.Consultor,
                    Password = "2222",
                    DischargeDate = null
                });
        }
    }
}
