using System.Text.Json;
using System.Text.Json.Serialization;
using DotnetInterviewTask.Context;
using DotnetInterviewTask.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// .NET Secret Manager is used to securely store Azure Cosmos DB configuration settings.
builder.Services.AddDbContext<ApplicationContext>(options =>
	options.UseCosmos(
    	builder.Configuration["DbAccountUrl"],
        builder.Configuration["DbPassword"],
        builder.Configuration["Database"]
    ));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMapster();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

