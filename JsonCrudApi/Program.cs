using jsoncrudapi.Services;
using JsonCrudApi.Repositories;
using  jsoncrudapi.Repositories.Emp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService,EmployeeService>();

var app = builder.Build();
app.UseHttpsRedirection();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
app.Run();


