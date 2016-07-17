using System.Web.Mvc;
using MediatR;
using list = WorkTool.Core.Mediator.Projects.List;

namespace WorkTool.Controllers
{
    /// <summary>
    /// Controller for the home page.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="mediator">the mediator.</param>
        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public ActionResult Index()
        {
            list.Query query = new list.Query() { UserId = 1 };

            var result = this.mediator.Send(query);

            return this.View(result);
        }
    }
}