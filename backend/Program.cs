var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<backend.Clients.GeminiClient>();

builder.Services.AddScoped<backend.Services.WorkflowService>();

builder.Services.AddScoped<backend.Services.ExportService>();

builder.Services.AddScoped<backend.Services.OnshapePayloadService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();