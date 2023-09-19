using Microsoft.EntityFrameworkCore;
using TP_Integrador_Softtek_Backend.DataAccess.Repositories.Interfaces;
using TP_Integrador_Softtek_Backend.DTOs;
using TP_Integrador_Softtek_Backend.Entities;

namespace TP_Integrador_Softtek_Backend.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
             
        }

        public async Task<User?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Password == dto.Password);
        }
    }
}
