using ApiMarvel.Data;
using ApiMarvel.Repository;
using ApiMarvel.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BDComicsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Comics")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.TryAddScoped<IComicRepository, ComicRepository>();
builder.Services.TryAddScoped<IComicService, ComicService>();
builder.Services.TryAddScoped<IFavoriteComicRepository, FavoriteComicRepository>();
builder.Services.TryAddScoped<IFavoriteComicService, FavoriteComicService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
