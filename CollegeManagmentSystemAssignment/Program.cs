using CollegeManagmentSystem.Application.Interfaces.IRepositorys;
using CollegeManagmentSystem.Application.Interfaces.IServices;
using CollegeManagmentSystem.Infrastructure.Data;
using CollegeManagmentSystem.Infrastructure.ImplementingInterfaces.Repositorys;
using CollegeManagmentSystem.Infrastructure.ImplementingInterfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registering DapperContext
builder.Services.AddTransient<DapperContext>();

//Registering Services and Repository
builder.Services.AddScoped<IUserSignUpRepository,UserSignUpRepository>();
builder.Services.AddScoped<IUserSignUpService,UserSignUpService>();

//Adding Cores
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
