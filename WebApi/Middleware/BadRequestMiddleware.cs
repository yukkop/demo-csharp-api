using Microsoft.AspNetCore.Http.Features;

namespace WebApi.Middleware;

public class BadRequestMiddleware
{
    private readonly RequestDelegate _next;

    public BadRequestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == 400)
        {
            var responseFeature = context.Features.Get<IHttpResponseFeature>();
            var errorMessage = responseFeature?.ReasonPhrase;
        
            await Console.Error.WriteLineAsync($"code 400; \n error message: {errorMessage ?? "null"};");
        }
    }
}