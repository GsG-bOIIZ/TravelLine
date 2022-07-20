using WebAppUniversity.Repositories;
using WebAppUniversity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IFacultyRepository>(s => new FacultyRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IFacultyService, FacultyService>();

builder.Services.AddScoped<IGroupRepository>(s => new GroupRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IGroupService, GroupService>();

builder.Services.AddScoped<IStudentRepository>(s => new StudentRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();
app.MapControllers();
app.Run();