namespace Multi_Tenant_Web.Middleware
{
    public class TenantResolver
    {
        private readonly RequestDelegate _next;

        public TenantResolver(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers.TryGetValue("tenant", out  var tenantFromHeader);
            if (string.IsNullOrEmpty(tenantFromHeader) == false)
            {

            }
            await _next(context);
        }
    }
}
