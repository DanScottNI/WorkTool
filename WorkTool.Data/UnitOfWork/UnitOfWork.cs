using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WorkTool.Data.Repositories;
using WorkTool.Data.Repositories.Interfaces;
using WorkTool.Data.UnitOfWork.Interface;

namespace WorkTool.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection connection;
        private IDbTransaction transaction;

        private IProjectRepository projectRepository;
        private IUserRepository userRepository;

        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="connectionString">the connection string.</param>
        public UnitOfWork(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
            this.connection.Open();
            this.transaction = this.connection.BeginTransaction();
        }

        ~UnitOfWork()
        {
            this.Dispose1(false);
        }

        public IProjectRepository Projects
        {
            get
            {
                return this.projectRepository ?? (this.projectRepository = new ProjectRepository(this.transaction));
            }
        }

        public IUserRepository Users
        {
            get
            {
                return this.userRepository ?? (this.userRepository = new UserRepository(this.transaction));
            }
        }

        public void Commit()
        {
            try
            {
                this.transaction.Commit();
            }
            catch
            {
                this.transaction.Rollback();
                throw;
            }
            finally
            {
                this.transaction.Dispose();
                this.transaction = this.connection.BeginTransaction();
                this.ResetRepositories();
            }
        }

        public void Dispose()
        {
            this.Dispose1(true);
            GC.SuppressFinalize(this);
        }

        private void ResetRepositories()
        {
            this.projectRepository = null;
            this.userRepository = null;
        }

        private void Dispose1(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.transaction != null)
                    {
                        this.transaction.Dispose();
                        this.transaction = null;
                    }

                    if (this.connection != null)
                    {
                        this.connection.Dispose();
                        this.connection = null;
                    }
                }

                this.disposed = true;
            }
        }
    }
}