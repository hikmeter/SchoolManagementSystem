using EOkul.Application.Interfaces;
using EOkul.Application.Mapping;
using EOkul.Application.Services.Abstract;
using EOkul.Application.Services.Concrete;
using EOkul.Persistence.Context;
using EOkul.Persistence.Repository;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IClassroomService, ClassroomService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddAutoMapper(typeof(GeneralMapping));

builder.Services.AddOpenApi();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.MapScalarApiReference(opt =>
{
    opt.Title = "EOkul Yönetim Bilgi Sistemi";
    opt.Theme = ScalarTheme.BluePlanet;
    opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();