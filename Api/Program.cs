using CodeExercise.Data.Repos;
using CodeExercise.Domain.Models;
using CodeExercise.Domain.Repos;
using CodeExercise.Domain.Services;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IClockMappingRepo, ClockMappingRepo>();
builder.Services.AddTransient<IClockRepo, ClockRepo>();
builder.Services.AddTransient<ClockTenantService>();
builder.Services.AddTransient<ClockService>();
builder.Services.AddScoped((s) =>
{
    HttpContext? httpContext = s.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
    if (httpContext != null)
	{
        Tenant? tenant = httpContext.Items["Tenant"] as Tenant;
        if (tenant != null)
        {
            return tenant;
        }
    }
    return new Tenant("");   
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.Use(async (context, next) =>
{
    Tenant? tenant = null;
    string sn = context.Request.Query["sn"];
    ClockTenantService? clockTenantService = context.RequestServices.GetService<ClockTenantService>();
    if (clockTenantService != null && int.TryParse(sn, out int serialNo))
    {
        tenant = await clockTenantService.GetClockTenant(serialNo);
        if (tenant != null)
		{
            context.Items["Tenant"] = tenant;
		}
    }
    if (tenant == null)
	{
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        await context.Response.StartAsync();
        return;
	}
    // Call the next delegate/middleware in the pipeline.
    await next(context);
});

app.UseAuthorization();

app.MapControllers();

app.Run();
