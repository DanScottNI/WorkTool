using System;
using WorkTool.Data.Repositories;

namespace WorkTool.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository ProjectRepository { get; }
        void Commit();
    }
}
