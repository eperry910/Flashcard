using Services;
using Entities;
using Microsoft.EntityFrameworkCore;
var MyAllowSpecificOrigins = "*";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(MyAllowSpecificOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod(); // add the allowed origins  
        });
});
// Add services to the container.
builder.Services.AddScoped<FlashcardServices>();
builder.Services.AddDbContext<FlashcardContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CardsDb")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
