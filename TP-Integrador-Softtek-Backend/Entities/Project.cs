using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Integrador_Softtek_Backend.Entities
{
    public class Project
    {
        [Key]
        [Column ("codProyecto")]
        public int Id { get; set; }

        [Required]
        [Column("nombre", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column("direccion", TypeName = "VARCHAR(100)")]
        public string Address { get; set; }

        [Required]
        [Column("estado", TypeName = "TINYINT")]
        public StateProject State { get; set; }

        public enum StateProject
        {
            Pendiente = 1,
            Confirmado = 2,
            Terminado = 3,
        }

        [Required]
        [Column("fechaBaja", TypeName = "DATE")]
        public DateTime DischargeDate { get; set; }
    }
}
