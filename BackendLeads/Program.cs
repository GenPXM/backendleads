using BackendLeads.Data;
using BackendLeads.Service;
using BackendLeads.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Database"))
                    );
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
    builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithMethods("GET", "PUT", "DELETE", "POST", "PATCH")
    );
});
builder.Services.AddScoped<IGestorService, GestorService>();    



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
