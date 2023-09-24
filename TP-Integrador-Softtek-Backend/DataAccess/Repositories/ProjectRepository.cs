using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;
using TP_Integrador_Softtek_Backend.DataAccess.Repositories.Interfaces;
using TP_Integrador_Softtek_Backend.DTOs;
using TP_Integrador_Softtek_Backend.Entities;
using static TP_Integrador_Softtek_Backend.Entities.Project;

namespace TP_Integrador_Softtek_Backend.DataAccess.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {

        }


        public override async Task<List<Project>> GetAll()
        {
            return await _context.Projects.Where(x => x.DischargeDate == null).ToListAsync();
        }


        public async Task<List<Project>> GetByState(int state)
        {
            return await _context.Projects.Where(x => x.State == (StateProject)state && x.DischargeDate == null).ToListAsync();
        }


        public override async Task<Project?> GetById(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }


        public override async Task<bool> Update(Project updateProject)
        {
            var Project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == updateProject.Id);

            if (Project == null)
            {
                return false;
            }

            Project.Name= updateProject.Name;
            Project.Address = updateProject.Address;
            Project.State = updateProject.State;
            Project.DischargeDate = updateProject.DischargeDate;

            _context.Projects.Update(Project);
            return true;
        }


        public override async Task<bool> Delete(int id)
        {
            var Project = await _context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (Project == null)
            {
                return false;
            }

            Project.DischargeDate = DateTime.Now;

            _context.Projects.Update(Project);
            return true;
        }
    }
}
