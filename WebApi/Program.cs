using Infrastructure.Services;
using Infrastructure.Interfaces;
using Domain.Entities;
using Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IStudentsService, StudentsService>();

// Add services to the container.

builder.Services.AddScoped<DataContext>();

builder.Services.AddScoped<StudentsService>();           
builder.Services.AddScoped<GroupsService>();           
builder.Services.AddScoped<MentorsService>();           
builder.Services.AddScoped<CoursesService>();           
builder.Services.AddScoped<StudentsGroupsService>();           
builder.Services.AddScoped<StatisticsService>();           

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My App"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseStaticFiles();

app.Run();