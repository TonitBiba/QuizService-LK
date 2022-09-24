namespace QuizService.Controllers {
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase, IAsyncActionFilter {

        [NonAction]
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            await next();
        }
    }
}
