using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TP_Integrador_Softtek_Backend.DTOs;

namespace TP_Integrador_Softtek_Backend.Entities
{
    public class Service
    {
        public Service(ServiceDto dto)
        {
            Description = dto.Description;
            State = dto.State;
            HourValue = dto.HourValue;
        }

        public Service(ServiceDto dto, int id)
        {
            Id = id;
            Description = dto.Description;
            State = dto.State;
            HourValue = dto.HourValue;
        }


        public Service()
        {

        }


        [Key]
        [Column("codServicio")]
        public int Id { get; set; }

        [Required]
        [Column("descr", TypeName = "VARCHAR(100)")]
        public string Description { get; set; }

        [Required]
        [Column("estado", TypeName = "BIT")]
        public bool State { get; set; }

        [Required]
        [Column("valorHora", TypeName = "NUMERIC(8,2)")]
        public double HourValue { get; set; }
    }
}
