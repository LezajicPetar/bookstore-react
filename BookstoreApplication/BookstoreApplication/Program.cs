using BookstoreApplication.Data;
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

builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<AwardRepository>();
builder.Services.AddScoped<AwardService>();
builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<PublisherRepository>();
builder.Services.AddScoped<PublisherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aktiviraj CORS pre bilo kog mapiranja kontrolera ili autorizacije
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
