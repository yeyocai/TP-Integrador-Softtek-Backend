using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador_Softtek_Backend.Entities
{
    public class Work
    {
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

        //[Required]
        [Column("fechaBaja", TypeName = "DATE")]
        public DateTime? DischargeDate { get; set; }

        //[ForeignKey("ProjectId")]
        //public Project Project { get; set; }

        //[ForeignKey("ServiceId")]
        //public Service Service { get; set; }
    }
}
