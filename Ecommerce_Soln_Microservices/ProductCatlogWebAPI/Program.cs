using ProductWebAPI.Repositories;
using ProductWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add services to the container
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// 🔹 Register Repository & Service (BEFORE Build)
builder.Services.AddScoped<IFlowerRepository, FlowerRepository>();
builder.Services.AddScoped<IFlowerService, FlowerService>();

var app = builder.Build();

// 🔹 Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
