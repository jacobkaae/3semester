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

Spørgsmål[] Quiz = new Spørgsmål[]
{
    new Spørgsmål { Id = nextId++, SpgText = "Hvor mange brødre har Jacob?", Svarmuligheder = new string[] { "En", "To", "Tre", "Fire" }, SvarIndex = 1},
    new Spørgsmål { Id = nextId++, SpgText = "Hvilken drikkevarer har Jacob på foden?", Svarmuligheder = new string[] { "Tequila", "Sambuca", "Bajer", "Vand(lol)"}, SvarIndex = 2}
};

// GET /api/questions: Henter alle spørgsmål og deres svarmuligheder, men ikke hvilke svar der er de rigtige
app.MapGet("/api/questions", () => {
    var nytarray = Quiz.Select(p => new Spg
    {
        spg = p.SpgText,
        spgvalg = p.Svarmuligheder.ToArray()
    }).ToArray();

    return nytarray;
}); 





// GET /api/tasks/{id}
//app.MapGet("/api/tasks/{id}", (int id) => Huskeliste.Where(p => p.Id == id));

// PUT /api/tasks/{id}
//app.MapPut("/api/tasks/{id}", (int id, Task opdTask) =>
//{
//    return Huskeliste = Huskeliste.Select(x =>
//    {
//        if (x.Id == id)
//        {
//            x = opdTask;
//            x.Id = id;
//            return x;
//        } else
//        {
//            return x;
//        }
//    }).ToArray();

// Best practice
//return Huskeliste = Huskeliste.Select(x => x.Id == id ? opdTask : x).ToArray();

//});


// DELETE /api/tasks/{id}
//app.MapDelete("/api/tasks/{id}", (int id) => Huskeliste = Huskeliste.Where(x => x.Id != id).ToArray());


// POST /api/tasks/
//app.MapPost("/api/tasks", (Task nyTask) => {
//    nyTask.Id = nextId++;
//    return Huskeliste = Huskeliste.Append(nyTask).ToArray();
//});

app.Run();


record Spg(string spg, string[] spgvalg);

public class Spørgsmål
{
    public long Id { get; set; }
    public string SpgText { get; set; }
    public string[] Svarmuligheder { get; set; }
    public int SvarIndex { get; set; }
}

