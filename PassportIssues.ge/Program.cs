using Microsoft.EntityFrameworkCore;
using PassportIssues.Repository.Apstractions;
using PassportIssues.Repository.Dbcontext;
using PassportIssues.Repository.Implementation;
using PassportIssues.Services.Abstractions;
using PassportIssues.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<ApplicationManagementContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<DbContext, ApplicationManagementContext>();
builder.Services.AddTransient<IApplicationFormService, ApplicationFormService>();
builder.Services.AddTransient<IApplicationFormRepository, ApplicationFormRepository>();


    
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
