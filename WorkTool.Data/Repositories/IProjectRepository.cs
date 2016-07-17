using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTool.Data.Models;

namespace WorkTool.Data.Repositories
{
    public interface IProjectRepository
    {
        void Add(Project entity);

        IEnumerable<Project> All();

        void Delete(int id);

        void Delete(Project entity);

        Project Find(int id);

        Project FindByName(string name);

        IEnumerable<Project> FindByUserId(int userId);

        void Update(Project entity);
    }
}
