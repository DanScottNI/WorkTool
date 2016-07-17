using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace WorkTool.Core.Mediator.Projects.Create
{
    public class Command : IRequest<Result>
    {
        public string Name { get; set; }
    }
}
