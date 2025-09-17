namespace MVCApp.Middleware
{
    public class DummyMiddleware
    {
        private readonly RequestDelegate _next;
        public DummyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("Dummy-Auth", out var token) || token != "st")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("unauthorized access");
                return;
            }
            await _next(context);
        }
    }
}