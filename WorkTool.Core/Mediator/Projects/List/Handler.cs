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

        /// <summary>
        /// Initializes a new instance of the <see cref="Handler"/> class.
        /// </summary>
        /// <param name="unitOfWork">the unit of work.</param>
        public Handler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Result Handle(Query message)
        {
            Result result = new Result();

            IEnumerable<Project> projects = null;

            // TODO Make this work, so it returns a users projects.
            projects = this.unitOfWork.Projects.All();

            result.Results = Mapper.Map<Collection<ProjectItemResult>>(projects);

            return result;
        }
    }
}
