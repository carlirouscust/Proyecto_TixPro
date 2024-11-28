namespace Proyecto_TixPro;

public class HttpContextAccessorMiddleware
{
    private readonly RequestDelegate _next;

    public HttpContextAccessorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IHttpContextAccessor httpContextAccessor)
    {
        // Asigna el HttpContext actual al IHttpContextAccessor
        httpContextAccessor.HttpContext = context;

        // Llama al siguiente middleware en la tubería
        await _next(context);
    }
}
