var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.MapGet("/api/hello", () => new { Message = "Hello World!" });

app.MapGet("/api/hello/{name}", (string name) => new { Message = $"Hej {name}!"});

app.MapGet("/api/hello/{name}/{age}", (string name, int age) => new { Message = $"Hello {name} you are {age} år gammel!"});


app.Run();
