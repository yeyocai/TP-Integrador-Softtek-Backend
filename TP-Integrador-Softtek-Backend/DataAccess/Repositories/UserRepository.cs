using TP_Integrador_Softtek_Backend.DataAccess.Repositories.Interfaces;
using TP_Integrador_Softtek_Backend.Entities;

namespace TP_Integrador_Softtek_Backend.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
             
        }
    }
}
