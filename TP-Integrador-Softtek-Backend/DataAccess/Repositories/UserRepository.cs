using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_Integrador_Softtek_Backend.DataAccess.Repositories.Interfaces;
using TP_Integrador_Softtek_Backend.DTOs;
using TP_Integrador_Softtek_Backend.Entities;
using TP_Integrador_Softtek_Backend.Helper;

namespace TP_Integrador_Softtek_Backend.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
             
        }


        public override async Task<List<User>> GetAll()
        {
            return await _context.Users.Where(x => x.DischargeDate == null).ToListAsync();
        }


       public override async Task<User?> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.DischargeDate == null);
        }


        public override async Task<bool> Update(User updateUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updateUser.Id);

            if (user == null)
            {
                return false;
            }

            user.Name = updateUser.Name;
            user.Dni = updateUser.Dni;
            user.Type = updateUser.Type;
            user.Email = updateUser.Email;
            user.Password = updateUser.Password;
            user.DischargeDate = updateUser.DischargeDate;

            _context.Users.Update(user);
            return true;
        }


        public override async Task<bool> Delete(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync(); 

            if (user == null)
            {
                return false;
            }

            user.DischargeDate = DateTime.Now;

            _context.Users.Update(user);
            return true;
        }


        public async Task<User?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Password == PasswordEncryptHelper.EncryptPassword(dto.Password));
        }
    }
}
