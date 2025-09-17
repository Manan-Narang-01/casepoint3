namespace MVCApp.Middleware
{
    public class DummyAuthMiddleware
    {
        private readonly RequestDelegate _next;
        public DummyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers["Dummy-Auth"] = "st";
            await _next(context);
        }
    }
}