using Microsoft.AspNetCore.Mvc;
using TP_Integrador_Softtek_Backend.Entities;

namespace TP_Integrador_Softtek_Backend.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll();

        public Task<T?> GetById(int id);

        public Task<bool> Update(T entity);

        public Task<bool> Delete(int id);
    }
}
