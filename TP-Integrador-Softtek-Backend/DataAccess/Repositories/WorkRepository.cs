using Microsoft.EntityFrameworkCore;
using TP_Integrador_Softtek_Backend.DataAccess.Repositories.Interfaces;
using TP_Integrador_Softtek_Backend.Entities;

namespace TP_Integrador_Softtek_Backend.DataAccess.Repositories
{
    public class WorkRepository : Repository<Work>, IWorkRepository
    {
        public WorkRepository(ApplicationDbContext context) : base(context)
        {

        }


        public override async Task<List<Work>> GetAll()
        {
            return await _context.Works.Where(x => x.DischargeDate == null).ToListAsync();
        }


        public override async Task<Work?> GetById(int id)
        {
            return await _context.Works.FirstOrDefaultAsync(x => x.Id == id && x.DischargeDate == null);
        }


        public override async Task<bool> Update(Work updateWork)
        {
            var work = await _context.Works.FirstOrDefaultAsync(x => x.Id == updateWork.Id);

            if (work == null)
            {
                return false;
            }

            work.Date = updateWork.Date;
            work.ProjectId = updateWork.ProjectId;
            work.ServiceId = updateWork.ServiceId;
            work.NumberOfHours = updateWork.NumberOfHours;
            work.HourValue = updateWork.HourValue;
            work.Cost = updateWork.Cost;
            work.DischargeDate = updateWork.DischargeDate;
 
            _context.Works.Update(work);
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
    }
}
