var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddOpenApi();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Endpoints
app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        Service = "InventoryService",
        Version = "1.0.0",
        Status = "Running"
    });
});

app.Run();