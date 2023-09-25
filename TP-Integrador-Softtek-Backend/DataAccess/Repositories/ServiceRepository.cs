using Microsoft.EntityFrameworkCore;
using TP_Integrador_Softtek_Backend.DataAccess.Repositories.Interfaces;
using TP_Integrador_Softtek_Backend.Entities;

namespace TP_Integrador_Softtek_Backend.DataAccess.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context) : base(context)
        {

        }


        public override async Task<List<Service>> GetAll()
        {
            return await _context.Services.Where(x => x.State == true).ToListAsync();
        }


        public override async Task<Service?> GetById(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(x => x.Id == id && x.State == true);
        }


        public override async Task<bool> Update(Service updateService)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == updateService.Id);

            if (service == null)
            {
                return false;
            }

            service.Description = updateService.Description;
            service.State = updateService.State;
            service.HourValue = updateService.HourValue;
 
            _context.Services.Update(service);
            return true;
        }


        public override async Task<bool> Delete(int id)
        {
            var service = await _context.Services.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (service == null)
            {
                return false;
            }

            service.State = false;

            _context.Services.Update(service);
            return true;
        }
    }
}
