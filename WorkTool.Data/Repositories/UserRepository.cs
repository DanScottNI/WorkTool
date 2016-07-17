using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WorkTool.Data.Models;
using WorkTool.Data.Repositories.Common;
using WorkTool.Data.Repositories.Interfaces;

namespace WorkTool.Data.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="transaction">the db transaction.</param>
        public UserRepository(IDbTransaction transaction)
            : base(transaction)
        {
        }

        public IEnumerable<User> All()
        {
            return this.Connection.Query<User>(
                "SELECT * FROM User",
                transaction: this.Transaction).ToList();
        }

        public User Find(int id)
        {
            return this.Connection.Query<User>(
                "SELECT * FROM User WHERE UserId = @UserId",
                param: new { UserId = id },
                transaction: this.Transaction).FirstOrDefault();
        }

        public void Add(User entity)
        {
            entity.UserId = this.Connection.ExecuteScalar<int>(
                "INSERT INTO User(Name) VALUES(@Name); SELECT SCOPE_IDENTITY()",
                param: new { Name = entity.Name },
                transaction: this.Transaction);
        }

        public void Update(User entity)
        {
            this.Connection.Execute(
                "UPDATE User SET Name = @Name WHERE UserId = @UserId",
                param: new { Name = entity.Name, UserId = entity.UserId },
                transaction: this.Transaction);
        }

        public void Delete(int id)
        {
            this.Connection.Execute(
                "DELETE FROM User WHERE UserId = @UserId",
                param: new { UserId = id },
                transaction: this.Transaction);
        }

        public void Delete(User entity)
        {
            this.Delete(entity.UserId);
        }

        public User FindByName(string name)
        {
            return this.Connection.Query<User>(
                "SELECT * FROM User WHERE Name = @Name",
                param: new { Name = name },
                transaction: this.Transaction).FirstOrDefault();
        }
    }
}
