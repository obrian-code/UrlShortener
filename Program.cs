var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:5184", "https://localhost:7184");

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();


app.UseCors("AllowAll");
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();
