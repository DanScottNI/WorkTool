using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using MediatR;
using WorkTool.Data.Models;
using WorkTool.Data.UnitOfWork.Interface;

namespace WorkTool.Core.Mediator.Projects.List
{
    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly IUnitOfWork unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Result Handle(Query message)
        {
            Result result = new Result();

            IEnumerable<Project> projects = null;

            if (message.UserId.HasValue)
            {
                projects = this.unitOfWork.ProjectRepository.All();
            }
            else
            {
                projects = this.unitOfWork.ProjectRepository.All();
            }

            result.Results = Mapper.Map<Collection<ProjectItemResult>>(projects);

            return result;
        }
    }
}
