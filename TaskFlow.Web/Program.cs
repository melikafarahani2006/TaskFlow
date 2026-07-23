using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;
using TaskFlow.Application.Projects.Interfaces;
using TaskFlow.Application.Projects.Services;
using TaskFlow.Application.TaskLists.Interfaces;
using TaskFlow.Application.TaskLists.Services;
using TaskFlow.Application.Workspaces.Interfaces;
using TaskFlow.Application.Workspaces.Services;
using TaskFlow.Infrastructure.Persistence;
using TaskFlow.Infrastructure.Persistence.Repositories;
using TaskFlow.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssembly(Assembly.Load("TaskFlow.Application"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskListRepository, TaskListRepository>();
builder.Services.AddScoped<ITaskListService, TaskListService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapStaticAssets();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
