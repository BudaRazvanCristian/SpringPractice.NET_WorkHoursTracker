using WorkHoursTracker.API.Data;
using WorkHoursTracker.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// String de conexiune MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurare EF Core + MySQL (Pomelo)
builder.Services.AddDbContext<WorkDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddSwaggerGen(c =>{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkHours API", Version = "v1" });
});


builder.Services.AddScoped<IWorkService, WorkService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
