using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TP_Integrador_Softtek_Backend.DataAccess.Repositories.Interfaces;

namespace TP_Integrador_Softtek_Backend.DataAccess.Repositories
{
    public class Repository <T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
