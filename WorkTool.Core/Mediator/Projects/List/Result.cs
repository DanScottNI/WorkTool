using System.Collections.ObjectModel;

namespace WorkTool.Core.Mediator.Projects.List
{
    public class Result
    {
        public Collection<ProjectItemResult> Results { get; set; }
    }

    public class ProjectItemResult
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
