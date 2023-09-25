using TP_Integrador_Softtek_Backend.DataAccess.Repositories;

namespace TP_Integrador_Softtek_Backend.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
        public ProjectRepository ProjectRepository { get; } 
        public ServiceRepository ServiceRepository { get; } 
        public WorkRepository WorkRepository { get; } 

        Task<int> Complete();
    }
}
