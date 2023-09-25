using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TP_Integrador_Softtek_Backend.DTOs;
using TP_Integrador_Softtek_Backend.Helper;

namespace TP_Integrador_Softtek_Backend.Entities
{
    public class User
    {
        public User(RegisterDto dto)
        {
            Name = dto.Name;
            Dni = dto.Dni;
            Type = dto.Type;
            Email = dto.Email;
            RoleId = 2;
            Password = PasswordEncryptHelper.EncryptPassword(dto.Password);
            DischargeDate = null;
        }

        public User(RegisterDto dto, int id)
        {
            Id = id;
            Name = dto.Name;
            Dni = dto.Dni;
            Type = dto.Type;
            Email = dto.Email;
            RoleId = dto.RoleId;
            Password = PasswordEncryptHelper.EncryptPassword(dto.Password);
            DischargeDate = dto.DischargeDate;
        }

        public User()
        {

        }


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
        [Column("email", TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

        [Required]
        [Column("contrasenia", TypeName = "VARCHAR(250)")]
        public string Password { get; set; }

        [Column("fechaBaja", TypeName = "DATE")]
        public DateTime? DischargeDate { get; set; }

        [Required]
        [Column("rol")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
