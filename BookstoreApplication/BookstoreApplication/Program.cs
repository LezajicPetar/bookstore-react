using BookstoreApplication.Data;
using BookstoreApplication.Middleware;
using BookstoreApplication.Models;
using BookstoreApplication.Profiles;
using BookstoreApplication.Repository;
using BookstoreApplication.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Dodaj CORS servis
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // adresa gde ti radi React app
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LeafDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAwardRepository, AwardRepository>();
builder.Services.AddScoped<IAwardService, AwardService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IPublisherService, PublisherService>();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();


builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<BookProfile>();
    cfg.AddProfile<AwardProfile>();
    cfg.AddProfile<PublisherProfile>();
    cfg.AddProfile<AuthorProfile>();
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
