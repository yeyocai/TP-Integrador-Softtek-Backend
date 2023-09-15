using TP_Integrador_Softtek_Backend.DataAccess.Repositories;

namespace TP_Integrador_Softtek_Backend.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }

        Task<int> Complete();
    }
}
