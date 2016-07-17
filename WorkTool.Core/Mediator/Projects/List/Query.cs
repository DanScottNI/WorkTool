using MediatR;

namespace WorkTool.Core.Mediator.Projects.List
{
    public class Query : IRequest<Result>
    {
        public int? UserId { get; set; }
    }
}
