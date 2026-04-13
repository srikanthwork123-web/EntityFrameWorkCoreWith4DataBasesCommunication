using EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Repositories;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder is one depencyinjection container.
//we need to register the application dependencies into this container.
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//register your context class and pointing to your connectionstring
//you should tell to ef core this context class is pointing to this database.
builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeCodeFirstApproachDatabase")));
//To implement the depency Injection must and stood register the interfacename,interfaceimplemented class here.
//If you are not registered it will throw "System.InvalidOpertionException:Unable to reslove service type" Error
//These interfaces we are injecting into controller constructor,to  implement the loosely coupling between the classes
//=======================***************must and Stood register like this way*********************
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//=======================***************************************************************************

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
