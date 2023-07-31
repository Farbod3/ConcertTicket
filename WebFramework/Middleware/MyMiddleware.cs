using Microsoft.AspNetCore.Http;

namespace WebFramework.Middleware;

public class MyMiddleware  
{
    private readonly RequestDelegate _next;

    public MyMiddleware (RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);
    }
}