using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TP_Integrador_Softtek_Backend.Entities;
using TP_Integrador_Softtek_Backend.Helper;

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
                    Email = "juan.perez@gmail.com",
                    Password = PasswordEncryptHelper.EncryptPassword("1234"),
                    RoleId = 1,
                    DischargeDate = null
                },

                new User
                {
                    Id = 2020,
                    Name = "Maria Lopez",
                    Dni = 22111555,
                    Type = User.UserType.Consultor,
                    Email = "maria.lopez@gmail.com",
                    Password = PasswordEncryptHelper.EncryptPassword("2222"),
                    RoleId = 2,
                    DischargeDate = null
                });
        }
    }
}
