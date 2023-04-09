using Module.Orders.Domain.Services;

namespace ModuleStruct.Middlewares
{
    public class LastRequestTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILastRequestService _lastRequestService;

        public LastRequestTimeMiddleware(RequestDelegate next, ILastRequestService lastRequestService)
        {
            _next = next;
            _lastRequestService = lastRequestService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var customerId = context.Request.Cookies["customerId"]?.ToString();
            if (string.IsNullOrEmpty(customerId))
            {
                customerId = Guid.NewGuid().ToString();
                context.Response.Cookies.Append("customerId", customerId);
            }

            await _lastRequestService.SaveAsync(customerId);

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
}
