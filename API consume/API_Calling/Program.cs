

var builder = WebApplication.CreateBuilder(args);

// ✅ Add Controllers
builder.Services.AddControllers();

// ✅ Register HttpClient (External Java API)
builder.Services.AddHttpClient<IResultRepository, ResultRepository>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5201/"); // 🔥 Java API URL
});

// ✅ Register Services
builder.Services.AddScoped<IResultService, ResultService>();

// ✅ Swagger (optional but helpful)
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// ❌ Optional: remove if giving HTTPS warning
// app.UseHttpsRedirection();

app.UseAuthorization();

// ✅ VERY IMPORTANT (fixes 404)
app.MapControllers();


app.Run();