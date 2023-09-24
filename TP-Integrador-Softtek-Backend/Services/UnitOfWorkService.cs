using TP_Integrador_Softtek_Backend.DataAccess;
using TP_Integrador_Softtek_Backend.DataAccess.Repositories;

namespace TP_Integrador_Softtek_Backend.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UserRepository UserRepository { get; private set; }
        public ProjectRepository ProjectRepository { get; private set; }
        public ServiceRepository ServiceRepository { get; private set; }
        public WorkRepository WorkRepository { get; private set; }


        public UnitOfWorkService(ApplicationDbContext context) 
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            ProjectRepository = new ProjectRepository(_context);
            ServiceRepository = new ServiceRepository(_context);
            WorkRepository = new WorkRepository(_context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
