using System;
using WorkTool.Data.Repositories;
using WorkTool.Data.Repositories.Interfaces;

namespace WorkTool.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository Projects { get; }

        IUserRepository Users { get; }

        void Commit();
    }
}
