using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static TP_Integrador_Softtek_Backend.Entities.Project;

namespace TP_Integrador_Softtek_Backend.DTOs
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public StateProject State { get; set; }
        public DateTime? DischargeDate { get; set; }
    }
}
