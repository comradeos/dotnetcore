var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IMyService, MyService>();

builder.Services.AddControllers();

var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware BEFORE");
    await next();
    Console.WriteLine("Middleware AFTER");
});

app.MapControllers();

app.Run();
