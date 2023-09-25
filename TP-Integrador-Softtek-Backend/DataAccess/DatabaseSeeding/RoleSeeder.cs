using Microsoft.EntityFrameworkCore;
using System;
using TP_Integrador_Softtek_Backend.Entities;
using TP_Integrador_Softtek_Backend.Helper;

namespace TP_Integrador_Softtek_Backend.DataAccess.DatabaseSeeding
{
    public class RoleSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(

                new Role
                {
                    Id = 1,
                    Name = "Administrador",
                    Description = "Administrador",
                    Active = true
                },

                new Role
                {
                    Id = 2,
                    Name = "Consultor",
                    Description = "Consultor",
                    Active = true
                });
        }
    }
}
