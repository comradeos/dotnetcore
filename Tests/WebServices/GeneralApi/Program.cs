using Microsoft.EntityFrameworkCore;
using GeneralApi.Database;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(opt => opt.UseSqlite("Data Source=mydatabase.db"));
    
WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseStatusCodePages(async context =>
{
    HttpRequest request = context.HttpContext.Request;
    HttpResponse response = context.HttpContext.Response;

    if (response.StatusCode == 404)
    {
        response.Redirect("/404");
    }
    
    await Task.CompletedTask;
});

app.Run();