using MgDbDemo.Configs;
using MgDbDemo.Profiles;
using MgDbDemo.Services;
using MgDbDemo.Services.Impl;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// MongoDB Settings
builder.Services.AddAutoMapper(typeof(BookProfile));
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(BookStoreDatabaseSettings)));
builder.Services.AddSingleton<IBookStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<BookStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IBookService, BookService>();
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