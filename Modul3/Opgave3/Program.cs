var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.MapGet("/api/hello", () => new { Message = "Hello World!" });

app.Run();
