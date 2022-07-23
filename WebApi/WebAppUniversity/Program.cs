using Microsoft.EntityFrameworkCore;
using WebAppUniversity.Infrastructure;
using WebAppUniversity.Repositories;
using WebAppUniversity.Services;
using WebAppUniversity.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/*builder.Services.AddScoped<IFacultyRepository>(s => new FacultyRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IFacultyService, FacultyService>();

builder.Services.AddScoped<IFacultyRepository>(s => new GroupRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IGroupService, GroupService>();

builder.Services.AddScoped<IStudentRepository>(s => new StudentRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IStudentService, StudentService>();*/

builder.Services.AddDbContext<UniversityDbContext>(c =>
{
    try
    {
        string connectionString = builder.Configuration.GetValue<string>("DefaultConnection");
        c.UseSqlServer(connectionString);
    }
    catch (Exception)
    {
        //var message = ex.Message;
    }
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();
app.MapControllers();
app.Run();