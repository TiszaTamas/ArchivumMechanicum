using ArchivumMechanicum.Data;
using ArchivumMechanicum.Logic.EntityLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient(typeof(Repositorium<>));
builder.Services.AddTransient<LocationLogic>();
builder.Services.AddTransient<RecordLogic>();
builder.Services.AddTransient<RelicLogic>();

builder.Services.AddDbContext<ArchivumContextus>(options =>
{
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ArchivumMechanicumDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");
    options.UseLazyLoadingProxies();
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
