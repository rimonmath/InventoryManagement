var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddOpenApi();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Health endpoint
app.MapGet("/", () => Results.Ok(new
{
    Service = "Inventory.Api",
    Version = "1.0.0",
    Status = "Running"
}));

app.Run();