using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using test_apis.Data;
using test_apis.Data.Model;
using test_apis.Ex;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomJwtAuth(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(op =>
      op.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
