using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP_Integrador_Softtek_Backend.DTOs
{
    public class WorkDto
    {
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public int ServiceId { get; set; }
        public int NumberOfHours { get; set; }
        public double HourValue { get; set; }
        public double Cost { get; set; }
        public DateTime? DischargeDate { get; set; }
    }
}
