using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador_Softtek_Backend.Entities
{
    public class User
    {
        [Key]
        [Column("codUsuario")]
        public int Id { get; set; }

        [Required]
        [Column("nombre", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column("dni", TypeName = "INT")]
        public int Dni { get; set; }

        [Required]
        [Column("tipo", TypeName = "TINYINT")]
        public UserType Type { get; set; }

        public enum UserType
        {
            Administrador = 1,
            Consultor = 2
        }

        [Required]
        [Column("contrasenia", TypeName = "VARCHAR(50)")]
        public string Password { get; set; }

        [Column("fechaBaja", TypeName = "DATE")]
        public DateTime? DischargeDate { get; set; }
    }
}
