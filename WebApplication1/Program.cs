using Microsoft.OpenApi.Models;
using Sat.Recruiment.Application.Common;
using Sat.Recruiment.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfraestructure();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sat.Recruiment.Api ", Version = "v1" });
}
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sat.Recruiment.Api v1"));
}

app.UseExceptionHandler("/api/Errors/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
