using static WebServer.Helper;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.Configure<List<DevicesListItem>>(builder.Configuration.GetSection("DevicesList"));

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Task task = Task.Run(() => ProcessDbSenderTasks());
Task task = Task.Run(() => queueManager.ProcessTasks());

app.Run();
