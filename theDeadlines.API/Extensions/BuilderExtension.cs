using Microsoft.EntityFrameworkCore;
using theDeadlines.Abstraction.IModels;
using theDeadlines.Abstraction.IRepositories;
using theDeadlines.Abstraction.IServices;
using theDeadlines.BLL.Services;
using theDeadlines.DAL.Models;
using theDeadlines.DAL.Repositories;

namespace theDeadlines.API.Extensions;

public static class BuilderExtension
{
    public static void AddAll(this WebApplicationBuilder builder)
    {
        builder.AddDbContext();
        builder.AddModels();
        builder.AddRepositories();
        builder.AddServices();
    }

    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        var configurationString = builder.Configuration.GetConnectionString("DeadlinesConnection");

        builder.Services.AddDbContext<DeadlinesContext>(options =>
            options.UseSqlServer(configurationString));
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IDeadlineService, DeadlineService>();
        builder.Services.AddScoped<ISubDeadlineService, SubDeadlineService>();
        builder.Services.AddScoped<IChecklistService, ChecklistService>();
        builder.Services.AddScoped<IChecklistItemService, ChecklistItemService>();
    }

    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IDeadlineRepository, DeadlineRepository>();
        builder.Services.AddScoped<ISubDeadlineRepository, SubDeadlineRepository>();
        builder.Services.AddScoped<IChecklistRepository, ChecklistRepository>();
        builder.Services.AddScoped<IChecklistItemRepository, ChecklistItemRepository>();
    }

    public static void AddModels(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IDeadline, Deadline>();
        builder.Services.AddScoped<ISubDeadline, SubDeadline>();
        builder.Services.AddScoped<IChecklist, Checklist>();
        builder.Services.AddScoped<IChecklistItem, ChecklistItem>();
    }
}