using ConwaysGameofLife.BusinessRules.Rules;
using ConwaysGameofLife.BusinessRules.Rules.Contracts;
using ConwaysGameofLife.Persistence.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// dependency-injection
builder.Services.AddSingleton<IBoardBL, BoardBL>();
builder.Services.AddSingleton<IGameOfLifeBL, GameOfLifeBL>();

builder.Services.AddSingleton<IBoardDAL, BoardDAL>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First())
);

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
