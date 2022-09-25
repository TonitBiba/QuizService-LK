namespace QuizService.General {
    using Microsoft.AspNetCore.Http.Extensions;
    using Newtonsoft.Json;
    using QuizService.Data;

    public class ExceptionHandlerMiddleware {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext context, QuizContext db) {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                await HandleExceptionMessageAsync(context, e, db);
            }
        }

        private static async Task HandleExceptionMessageAsync(HttpContext context, Exception exception, QuizContext db) {
            db.ChangeTracker.Clear();
            Log log = new()
            {
                Url = context.Request.GetDisplayUrl(),
                IsError = true,
                Exception = JsonConvert.SerializeObject(exception),
                HttpMethod = context.Request.Method,
            };

            if (context.Request.HasFormContentType)
            {
                IFormCollection form = await context.Request.ReadFormAsync();
                log.FormContent = JsonConvert.SerializeObject(form);
            }
            db.Log.Add(log);
            await db.SaveChangesAsync();

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }

    public static class ExpectionHandlerMiddlewareExtensions {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app) {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
