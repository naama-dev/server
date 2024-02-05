using Microsoft.EntityFrameworkCore;
using Models.Models;
using DAL.Data;
using DAL.Interface;
using MyProject.middleWare;
using Serilog;

string myCors = "_myCors";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUser,UserData>();
builder.Services.AddScoped<IPost,PostData>();
builder.Services.AddScoped<IPhoto, PhotoData>();
builder.Services.AddScoped<IToDo, ToDoData>();
builder.Services.AddDbContext<DataProjectContext>(item => item.UseSqlServer("Data Source=NAAMA\\MSSQLSERVER1;Initial Catalog=MyProject;Integrated Security=SSPI;Trusted_Connection=True;"));
builder.Services.AddCors(op =>
{
    op.AddPolicy(myCors,
        builder =>
        {
            builder.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(myCors);
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(@"C:\Users\USER\Desktop\הנדסאים יד\REACT\פרויקט גמר משימות\MyProject.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
app.UseMiddleware<ErrorGlobalMiddleWare>();
app.UseMiddleware<Middleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
