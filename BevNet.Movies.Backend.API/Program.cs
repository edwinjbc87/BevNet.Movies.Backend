using BevNet.Movies.Backend.Domain.Contracts;
using BevNet.Movies.Backend.Domain.Implementations;
using BevNet.Movies.Backend.Infrastructure.Contracts;
using BevNet.Movies.Backend.Infrastructure.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddHttpClient<IMoviesRepository, MoviesRepository>(cli => {
    cli.BaseAddress = new Uri(builder.Configuration.GetSection("AppSettings").GetValue<string>("ApiUrl"));
});
builder.Services.AddCors(opts => {
    opts.AddPolicy("General", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("General");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

