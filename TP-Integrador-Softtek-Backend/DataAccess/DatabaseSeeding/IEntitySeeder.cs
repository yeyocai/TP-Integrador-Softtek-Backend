using Microsoft.EntityFrameworkCore;

namespace TP_Integrador_Softtek_Backend.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabase(ModelBuilder modelBuilder);
    }
}
