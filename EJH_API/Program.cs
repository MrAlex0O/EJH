using AutoMapper;
using DataBase.Contexts;
using DataBase.Repositories;
using DataBase.Repositories.Interfaces;
using Logic.Profiles;
using Logic.Queries;
using Logic.Queries.Interfaces;
using Logic.ReadServices;
using Logic.ReadServices.Interfaces;
using Logic.WriteServices;
using Logic.WriteServices.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // устаревшее поведение Даты и Времени в postgreSQL
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();


builder.Services.AddScoped<IGroupWriteService, GroupWriteService>();
builder.Services.AddScoped<IGroupReadService, GroupReadService>();
builder.Services.AddScoped<IGroupQuery, GroupQuery>();

builder.Services.AddScoped<IPersonWriteService, PersonWriteService>();

builder.Services.AddScoped<IStudentWriteService, StudentWriteService>();
builder.Services.AddScoped<IStudentReadService, StudentReadService>();
builder.Services.AddScoped<IStudentQuery, StudentQuery>();

builder.Services.AddScoped<ITeacherWriteService, TeacherWriteService>();
builder.Services.AddScoped<ITeacherReadService, TeacherReadService>();
builder.Services.AddScoped<ITeacherQuery, TeacherQuery>();

builder.Services.AddScoped<IDisciplineWriteService, DisciplineWriteService>();
builder.Services.AddScoped<IDisciplineReadService, DisciplineReadService>();
builder.Services.AddScoped<IDisciplineQuery, DisciplineQuery>();

builder.Services.AddScoped<IAssistantWriteService, AssistantWriteService>();

builder.Services.AddScoped<ILessonTypeReadService, LessonTypeReadService>();
builder.Services.AddScoped<ILessonTypeQuery, LessonTypeQuery>();

builder.Services.AddScoped<ILessonWriteService, LessonWriteService>();
builder.Services.AddScoped<ILessonReadService, LessonReadService>();
builder.Services.AddScoped<ILessonQuery, LessonQuery>();

builder.Services.AddScoped<IStatusOnLessonReadService, StatusOnLessonReadService>();
builder.Services.AddScoped<IStatusOnLessonQuery, StatusOnLessonQuery>();

builder.Services.AddScoped<ILessonVisitorWriteService, LessonVisitorsWriteService>();
builder.Services.AddScoped<ILessonVisitorReadService, LessonVisitorReadService>();
builder.Services.AddScoped<ILessonVisitorQuery, LessonVisitorQuery>();

builder.Services.AddDbContext<IWebContext, Context>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


AutoMapper.IConfigurationProvider config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<GroupProfile>();
    cfg.AddProfile<StudentProfile>();
    cfg.AddProfile<DisciplineProfile>();
    cfg.AddProfile<LessonProfile>();
});

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
