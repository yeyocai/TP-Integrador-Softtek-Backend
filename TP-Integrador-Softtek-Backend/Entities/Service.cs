using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador_Softtek_Backend.Entities
{
    public class Service
    {
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
