using minhaApi.Data;
using minhaApi.Interface.Repository;
using minhaApi.Repository;
using minhaApi.Interface.Service;
using minhaApi.Service;


var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DapperContext>();

builder.Services.AddScoped<IUrlRepository, UrlRepository>();
builder.Services.AddScoped<IUrlService, UrlService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
