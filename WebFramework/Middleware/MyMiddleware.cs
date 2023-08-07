using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace WebFramework.Middleware;
public static class AddMyMiddlewares
{
    public static IApplicationBuilder MyMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyMiddleware>();
    }
}
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

    public async Task Invoke(HttpContext context)
    {
        var path = context.Request.Path!;
        if (!path.StartsWithSegments("/swagger", StringComparison.OrdinalIgnoreCase)
            && MimeType.TryGetValue(Path.GetExtension(path), out var mimeType))
        {
            var filePath = $"{Directory.GetCurrentDirectory()}/View{path.Value}";
            if (File.Exists(filePath))
            {
                var fileContent = await File.ReadAllTextAsync(filePath);
                context.Response.ContentType = mimeType;
                await context.Response.WriteAsync(fileContent);
                return;
            }
        }

        await _next(context);
    }
}

     
    