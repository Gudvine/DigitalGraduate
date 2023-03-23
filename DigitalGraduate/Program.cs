var builder = WebApplication.CreateBuilder(args);

// Useful variables
var connectionStringForTests = builder.Configuration.GetConnectionString("TestDbConnection");
var connectionStringTestIdentity = builder.Configuration.GetConnectionString("TestIdentity");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
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
