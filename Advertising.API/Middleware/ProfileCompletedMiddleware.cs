using Advertising.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Advertising.API.Middleware
{
    public class ProfileCompletedMiddleware
    {
        private readonly RequestDelegate _next;

        public ProfileCompletedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<User> userManager)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                // Apply only to campaign endpoints
                if (context.Request.Path.StartsWithSegments("/api/campaigns"))
                {
                    var userId = context.User.FindFirstValue("uid");
                    if (userId != null)
                    {
                        var user = await userManager.FindByIdAsync(userId);
                        if (user != null && !user.ProfileCompleted)
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            await context.Response.WriteAsync("Complete your profile before performing this action.");
                            return;
                        }
                    }
                }
            }

            await _next(context);
        }
    }
}

