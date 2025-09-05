using SistemaVentas.Api.Middleware;
using SistemaVentas.App;
using SistemaVentas.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prueba tecnica API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseMiddleware<AppExceptionHandlerMiddleware>();
app.UseMiddleware<DatabaseExceptionMiddleware>();
app.MapControllers();
app.Run();

public partial class Program { }
