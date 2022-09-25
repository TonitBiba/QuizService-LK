namespace QuizService.Controllers {
    using Microsoft.AspNetCore.Http.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;
    using QuizService.Data;
    using QuizService.General;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase, IAsyncActionFilter {
        protected QuizContext _db;
        protected LanguageEnum lang;

        public BaseController(QuizContext db) {
            _db = db;
        }

        [NonAction]
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            string? languageFromRequest = context.HttpContext.Request.Headers["lang"].FirstOrDefault();
            lang = (languageFromRequest == "sq" ? LanguageEnum.Albania : (languageFromRequest == "en" ? LanguageEnum.English : LanguageEnum.Norwegian));
            
            Log log = new()
            {
                HttpMethod = context.HttpContext.Request.Method,
                InsertedDate = DateTime.Now,
                Url = context.HttpContext.Request.GetDisplayUrl(),
            };

            log.FormContent = JsonConvert.SerializeObject(context.ActionArguments);

            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
                return;
            }

            try
            {
                var res = await next();
            }
            catch (Exception ex)
            {
                log.IsError = true;
                log.Exception = JsonConvert.SerializeObject(ex);
            }
            _db.Log.Add(log);
            await _db.SaveChangesAsync();
        }
    }

    public enum LanguageEnum {
        Albania = 1,
        English = 2,
        Norwegian = 3
    }

    public enum ErrorStatus {
        SUCCESS = 1,
        INFO = 2,
        WARNING = 3,
        ERROR = 4
    }
}
