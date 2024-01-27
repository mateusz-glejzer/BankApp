using System.Text;
using System.Threading.Tasks;
using BankApp.BankAccounts.Api;
using BankApp.Bootstrapper;
using BankApp.Identity.Api;
using BankApp.Identity.Core.Identity.Models;
using BankApp.Shared.Infrastructure;
using BankApp.Shared.Infrastructure.Configuration;
using BankApp.Transactions.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

ModulesExtensions.RegisterModule<TransactionsModule>();
ModulesExtensions.RegisterModule<IdentityModule>();
ModulesExtensions.RegisterModule<BankAccountsModule>();

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.AddModuleConfiguration();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(type => type.ToString()));
builder.Services.AddModules(builder.Configuration);
var jwtOptions = builder.Configuration.GetSection<JwtOptions>("Jwt");
builder.Services.AddSingleton(jwtOptions);
builder.Services.AddTransient<EndpointAuthorizationMiddleware>();
builder.Services.AddAuthentication(o =>
    {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = jwtOptions.ValidIssuer,
            ValidateIssuer = true,
            IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(jwtOptions.IssuerSigningKey)),
            ValidAlgorithms = new[] { jwtOptions.Algorithm },
            ValidateLifetime = false,
            ValidateAudience = false
        };
        o.Events = new JwtBearerEvents()
        {
            OnMessageReceived = ctx =>
            {
                var authHeader = ctx.Request.Headers["auth"].ToString();
                if (string.IsNullOrEmpty(authHeader))
                {
                    return Task.CompletedTask;
                }

                var auth = JsonConvert.DeserializeObject<AuthorizationDto>(authHeader);
                ctx.Token = auth.AccessToken;
                return Task.CompletedTask;
            }
        };
    });

var applicationBuilder = builder.Build();

applicationBuilder.UseSwagger();
applicationBuilder.UseSwaggerUI();
applicationBuilder.UseDeveloperExceptionPage();

applicationBuilder.UseRouting();
applicationBuilder.UseAuthorization();
applicationBuilder.UseEndpoints(endpointRouteBuilder =>
{
    endpointRouteBuilder.MapModulesEndpoints();
    endpointRouteBuilder.MapControllers();
});
applicationBuilder.UseMiddleware<EndpointAuthorizationMiddleware>();

applicationBuilder.Run();