var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();   // ✅ ADD THIS

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();   // ✅ ADD THIS

app.Run();
