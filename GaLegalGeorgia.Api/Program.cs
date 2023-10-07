using GaLegalGeorgia.Api.Middleware;
using GaLegalGeorgia.Application;
using GaLegalGeorgia.Infrastructure;
using GaLegalGeorgia.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddCors(options =>
{
    //   options.AddPolicy("all", builder => builder.AllowAnyOrigin()
    //   .AllowAnyHeader()
    //  .AllowAnyMethod());
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Allow requests from this origin
               .AllowAnyHeader()
               .AllowAnyMethod();
    });

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS middleware
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
