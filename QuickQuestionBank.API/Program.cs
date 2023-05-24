using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickQuestionBank.Application.Features.UserQuiz.Commands;
using QuickQuestionBank.Application.Features.UserQuiz.Handlers;
using QuickQuestionBank.Application.Helpers;
using QuickQuestionBank.Application.Interfaces.IRepository;
using QuickQuestionBank.Domain;
using QuickQuestionBank.Domain.DTOs;
using QuickQuestionBank.Domain.Entities;
using QuickQuestionBank.Infrastructure.Services.Repository;
using QuickQuestionBank.Infrastructure.Utils;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
#region Database config
builder.Services.AddDbContext<QuickQuestionDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    }));
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<QuickQuestionDbContext>();
#endregion
#region CustomServices
builder.Services.AddTransient<IQuizRepository, QuizRepository>();
builder.Services.AddTransient<IQuizQuestionRepository, QuizQuestionRepository>();
builder.Services.AddTransient<IQuestionTypeRepository, QuestionTypeRepository>();
builder.Services.AddTransient<IQuestionAnswerMappingRepository, QuestionAnswerMappingRepository>();
builder.Services.AddTransient<IQuizQuestionMappingRepository, QuizQuestionMappingRepository>();

#endregion
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader().WithOrigins("http://localhost:50401");
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
