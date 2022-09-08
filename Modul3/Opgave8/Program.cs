var builder = WebApplication.CreateBuilder(args);

var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors(AllowCors);

int nextId = 0;

Task[] Huskeliste = new Task[]
{
    new Task { Id = nextId++, Text = "Rydde op", Done = false},
    new Task { Id = nextId++, Text = "Vaske gulv", Done = false},
    new Task { Id = nextId++, Text = "Toiletter", Done = false}

};

// GET /api/tasks
app.MapGet("/api/tasks", () => Huskeliste);

// GET /api/tasks/{id}
app.MapGet("/api/tasks/{id}", (int id) => Huskeliste.Where(p => p.Id == id));

// PUT /api/tasks/{id}
app.MapPut("/api/tasks/{id}", (int id, Task opdTask) =>
{
    return Huskeliste = Huskeliste.Select(x =>
    {
        if (x.Id == id)
        {
            x = opdTask;
            x.Id = id;
            return x;
        } else
        {
            return x;
        }
    }).ToArray();

    // Best practice
    //return Huskeliste = Huskeliste.Select(x => x.Id == id ? opdTask : x).ToArray();

});


// DELETE /api/tasks/{id}
app.MapDelete("/api/tasks/{id}", (int id) => Huskeliste = Huskeliste.Where(x => x.Id != id).ToArray());


// POST /api/tasks/
app.MapPost("/api/tasks", (Task nyTask) => {
    nyTask.Id = nextId++;
    return Huskeliste = Huskeliste.Append(nyTask).ToArray();
});

app.Run();



public class Task
{
    public long Id { get; set; }
    public string Text { get; set; }
    public bool Done { get; set; }
}