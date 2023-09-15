namespace TP_Integrador_Softtek_Backend.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
    }
}
