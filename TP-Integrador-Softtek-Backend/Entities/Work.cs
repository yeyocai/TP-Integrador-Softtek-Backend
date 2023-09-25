using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;
using TP_Integrador_Softtek_Backend.DTOs;

namespace TP_Integrador_Softtek_Backend.Entities
{
    public class Work
    {
        public Work(WorkDto dto)
        {
            Date = dto.Date;
            ProjectId = dto.ProjectId;
            ServiceId = dto.ServiceId;
            NumberOfHours = dto.NumberOfHours;
            HourValue = dto.HourValue;
            Cost = dto.Cost;
            DischargeDate = dto.DischargeDate;
        }

        public Work(WorkDto dto, int id)
        {
            Id = id;
            Date = dto.Date;
            ProjectId = dto.ProjectId;
            ServiceId = dto.ServiceId;
            NumberOfHours = dto.NumberOfHours;
            HourValue = dto.HourValue;
            Cost = dto.Cost;
            DischargeDate = dto.DischargeDate;
        }

        public Work()
        {

        }


        [Key]
        [Column("codTrabajo")]
        public int Id { get; set; }

        [Required]
        [Column("fecha", TypeName = "DATE")]
        public DateTime Date { get; set; }

        [Required]
        [Column("codProyecto", TypeName = "INT")]
        public int ProjectId { get; set; }

        [Required]
        [Column("codServicio", TypeName = "INT")]
        public int ServiceId { get; set; }

        [Required]
        [Column("cantHoras", TypeName = "INT")]
        public int NumberOfHours { get; set; }

        [Required]
        [Column("valorHora", TypeName = "NUMERIC(8,2)")]
        public double HourValue { get; set; }

        [Required]
        [Column("costo", TypeName = "NUMERIC(10,2)")]
        public double Cost { get; set; }

        [Column("fechaBaja", TypeName = "DATE")]
        public DateTime? DischargeDate { get; set; }
    }
}
