using Microsoft.EntityFrameworkCore;
using aspnetwebapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<WorkflowDataItemContext>(opt => opt.UseInMemoryDatabase("WorkflowDataItems"));
builder.Services.AddDbContext<WorkflowStepContext>(opt => opt.UseInMemoryDatabase("WorkflowSteps"));
builder.Services.AddDbContext<WorkflowContext>(opt => opt.UseInMemoryDatabase("Workflows"));
builder.Services.AddDbContext<UserAccountContext>(opt => opt.UseInMemoryDatabase("UserAccounts"));
builder.Services.AddEndpointsApiExplorer(); // Swagger/OpenAPI doc https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

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
