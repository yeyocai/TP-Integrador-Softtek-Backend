using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Integrador_Softtek_Backend.Entities
{
    public class Role
    {
        [Column("codRol")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Name { get; set; }

        [Column("descripcion")]
        public string Description { get; set; }

        [Column("activo")]
        public bool Active { get; set; }
    }
}
