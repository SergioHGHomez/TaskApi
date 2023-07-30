using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;
using TaskApi.Service;

var builder = WebApplication.CreateBuilder(args);
string key = "1ucCpFKVEM7F7PnMJ1ZQ5S1du9bf8qosyTNQxIkt1T5K1=";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddSqlServer<Task_DBContext>("");*/
builder.Services.AddDbContext<Task_DBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskDB")));
builder.Services.AddScoped<IListService, ListService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
