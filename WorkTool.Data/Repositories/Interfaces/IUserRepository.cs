using System.Collections.Generic;
using WorkTool.Data.Models;

namespace WorkTool.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(User entity);

        IEnumerable<User> All();

        void Delete(int id);

        void Delete(User entity);

        User Find(int id);

        User FindByName(string name);

        void Update(User entity);
    }
}
