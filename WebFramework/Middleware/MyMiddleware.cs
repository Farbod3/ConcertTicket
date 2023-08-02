using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;

namespace WebFramework.Middleware;

public class MyMiddleware  
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<StaticFileMiddleware> _logger;

    private static readonly Dictionary<string, string> MimeType = new()
    {
        [".html"] = "text/html",
        [".css"] = "text/css",
        [".js"] = "application/javascript",
        [".png"] = "image/png",
        [".jpeg"] = "image/jpeg",
        [".gif"] = "image/gif",
        [".svg"] = "image/svgxml"
    };

    public MyMiddleware (RequestDelegate next, IWebHostEnvironment env, ILogger<StaticFileMiddleware> logger)
    {
        _next = next;
        _env = env;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path;
        if (!path.StartsWithSegments("/swagger", StringComparison.OrdinalIgnoreCase) &&
            MimeType.TryGetValue(Path.GetExtension(path), out var mimType))
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "View", path.Value ?? "");
            if (File.Exists(filepath))
            {
                var fileContent = await File.ReadAllTextAsync(filepath);
                context.Response.ContentType = mimType;
                await context.Response.WriteAsync(fileContent);
                return;
            }
        }

        await _next(context);
    }
}