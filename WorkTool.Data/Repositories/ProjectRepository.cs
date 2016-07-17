using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WorkTool.Data.Models;

namespace WorkTool.Data.Repositories
{
    public class ProjectRepository : RepositoryBase, IProjectRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRepository"/> class.
        /// </summary>
        /// <param name="transaction">the db transaction.</param>
        public ProjectRepository(IDbTransaction transaction)
            : base(transaction)
        {
        }

        public IEnumerable<Project> All()
        {
            return this.Connection.Query<Project>(
                "SELECT * FROM Project",
                transaction: this.Transaction).ToList();
        }

        public Project Find(int id)
        {
            return this.Connection.Query<Project>(
                "SELECT * FROM Project WHERE ProjectId = @ProjectId",
                param: new { ProjectId = id },
                transaction: this.Transaction).FirstOrDefault();
        }

        public void Add(Project entity)
        {
            entity.ProjectId = this.Connection.ExecuteScalar<int>(
                "INSERT INTO Project(ProjectName) VALUES(@ProjectName); SELECT SCOPE_IDENTITY()",
                param: new { ProjectName = entity.ProjectName },
                transaction: this.Transaction);
        }

        public void Update(Project entity)
        {
            this.Connection.Execute(
                "UPDATE Project SET ProjectName = @ProjectName WHERE ProjectId = @ProjectId",
                param: new { ProjectName = entity.ProjectName, ProjectId = entity.ProjectId },
                transaction: this.Transaction);
        }

        public void Delete(int id)
        {
            this.Connection.Execute(
                "DELETE FROM Project WHERE ProjectId = @ProjectId",
                param: new { ProjectId = id },
                transaction: this.Transaction);
        }

        public void Delete(Project entity)
        {
            this.Delete(entity.ProjectId);
        }

        public Project FindByName(string name)
        {
            return this.Connection.Query<Project>(
                "SELECT * FROM Project WHERE ProjectName = @ProjectName",
                param: new { Name = name },
                transaction: this.Transaction).FirstOrDefault();
        }

        public IEnumerable<Project> FindByUserId(int userId)
        {
            return this.Connection.Query<Project>(
                "SELECT * FROM Project WHERE UserId = @UserId",
                param: new { UserId = userId },
                transaction: this.Transaction);
        }
    }
}
