using System.Threading.Tasks;
using BankApp.Identity.Core.Identity.Models;
using BankApp.Identity.Domain.User;
using BankApp.Shared.Infrastructure.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace BankApp.Bootstrapper;

public class EndpointAuthorizationMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var path = context.Request.Path.ToString().TrimStart('/');
        var method = context.Request.Method;
        var routeKey = new RouteInfo(path, method);
        
        var requiredAccess = ModulesExtensions.GetAccessLevel(routeKey);

        if (requiredAccess == AuthorizationLevel.Anonymous)
        {
            await next(context);
            return;
        }

        var cookie = context.Request.Cookies["auth"];
        var auth = JsonConvert.DeserializeObject<AuthorizationDto>(cookie);
        if (auth.Role is Roles.Client)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsJsonAsync("Unauthorized");
            return;
        }

        await next(context);
    }
}