using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;
using TP_Integrador_Softtek_Backend.Entities;

namespace TP_Integrador_Softtek_Backend.DataAccess.DatabaseSeeding
{
    public class ProjectSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(

                new Project
                {
                    Id = 10,
                    Name = "Extracción de gas en Vaca Muerta",
                    Address = "Humberto Primo 123",
                    State = Project.StateProject.Pendiente,
                    DischargeDate = null
                },

                new Project
                {
                    Id = 30,
                    Name = "Creación de gasoducto Nestor Kirchner",
                    Address = "Almafuerte 256",
                    State = Project.StateProject.Confirmado,
                    DischargeDate = null
                },
                
                new Project
                {
                    Id = 50,
                    Name = "Extracción de petóleo en Vaca Muerta",
                    Address = "Machado 255",
                    State = Project.StateProject.Terminado,
                    DischargeDate = null
                },


                new Project
                {
                    Id = 5,
                    Name = "Extracción de minerales",
                    Address = "Salta 123",
                    State = Project.StateProject.Terminado,
                    DischargeDate = new DateTime(2023,2,16)
                }); 
        }
    }
}
