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
//you should tell to entityframework core this context class is pointing to this database.
////If you are not registered this context class in AddDbContext<> section  it will throw "Unable to reslove service type" Error.
builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeCodeFirstApproachDatabase")));
builder.Services.AddDbContext<OrdersContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersCodeFirstApproachDatabase")));
builder.Services.AddDbContext<DepartmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DepartmentCodeFirstApproachDatabase")));
//To implement the depency Injection must and stood register the interfacename,interfaceimplemented class here.
//If you are not registered it will throw "System.InvalidOpertionException:Unable to reslove service type" Error
//These interfaces we are injecting into controller constructor,to  implement the loosely coupling between the classes
//*************WE MUST REGISTER THE INTERFACENAME,INTERFACEIMPLEMNTEDCHILDNAME CLASS NAME HERE**************
//=======================***************must and Stood register like this way*********************
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//=======================***************************************************************************
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
//=========================*******************************************************************
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDeparmentService, DeparmentService>();
//=========================*******************************************************************
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
