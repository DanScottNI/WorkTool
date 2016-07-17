using MediatR;
using WorkTool.Data.Models;
using WorkTool.Data.UnitOfWork.Interface;

namespace WorkTool.Core.Mediator.Projects.Create
{
    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly IUnitOfWork unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Result Handle(Command message)
        {
            Project proj = new Project();
            proj.ProjectName = message.Name;
            this.unitOfWork.ProjectRepository.Add(proj);
            this.unitOfWork.Commit();

            return new Result() { ProjectId = proj.ProjectId };
        }
    }
}
