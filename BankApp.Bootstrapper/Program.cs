using BankApp.BankAccounts.Api;
using BankApp.Bootstrapper;
using BankApp.Identity.Api;
using BankApp.Transactions.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

ModulesExtensions.RegisterModule<TransactionsModule>();
ModulesExtensions.RegisterModule<IdentityModule>();
ModulesExtensions.RegisterModule<BankAccountsModule>();

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureModules();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddModules(builder.Configuration);

var applicationBuilder = builder.Build();

applicationBuilder.UseSwagger();
applicationBuilder.UseSwaggerUI();
applicationBuilder.UseDeveloperExceptionPage();

applicationBuilder.UseRouting();
applicationBuilder.UseEndpoints(endpointRouteBuilder =>
{
    endpointRouteBuilder.MapModulesEndpoints();
    endpointRouteBuilder.MapControllers();
});

applicationBuilder.Run();