var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Task[] Huskeliste = new Task[]
{
    new Task { Id = 1, Text = "Rydde op", Done = false},
    new Task { Id = 2, Text = "Vaske gulv", Done = false},
    new Task { Id = 3, Text = "Toiletter", Done = false}

};

// GET /api/tasks
app.MapGet("/api/task", () => Huskeliste);

// GET /api/tasks/{id}
app.MapGet("/api/task/{id}", (int id) => Huskeliste.Where(p => p.Id == id));

// PUT /api/tasks/{id}
app.MapPut("/api/task/{id}", (int id, Task opdTask) =>
{
    if (Huskeliste.Where(p => p.Id == id) == null)
    {
        Console.WriteLine("Der findes ingen opgave med dette ID");

        return Huskeliste;
    }
    else
    {
        Huskeliste.Select(x => opdTask).Where(p => p.Id == id);

        return Huskeliste;
    }
});

app.Run();


public class Task
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool Done { get; set; }
}