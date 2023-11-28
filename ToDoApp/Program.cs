using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Implementations;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.MappingProfiles;
using ToDoApp.DAL;
using ToDoApp.DAL.Repository.Interfaces;
using ToDoApp.DAL.Repository.Repositories;
using ToDoApp.Web.Validation;

namespace ToDoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(ValidationFilter));
            });

            builder.Services.AddDbContext<ToDoAppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            builder.Services.AddScoped<ITaskService, TaskService>();

            builder.Services.AddAutoMapper(typeof(ToDoTaskMappingProfile));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Tasks}/{action=Index}");

            app.Run();
        }
    }
}