using static TP_Integrador_Softtek_Backend.Entities.User;

namespace TP_Integrador_Softtek_Backend.DTOs
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public int Dni { get; set; }
        public UserType Type { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DischargeDate { get; set; }
        public int RoleId { get; set; }
    }
}
