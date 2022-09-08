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
    var nytArray = Quiz.Select(p => new SpgUdenSvar
    {
       SpgText = p.SpgText,
       Svarmuligheder = p.Svarmuligheder
    });

    return nytArray;
});

// GET /api/questions/{id}: Henter et bestemt spørgsmål og dets svarmuligheder, men ikke hvilket svar der er det rigtige
app.MapGet("/api/questions/{id}", (int id) => {
    var nytArray = Quiz.Select(p => new SpgIdUdenSvar
    {
        Id = p.Id,
        SpgText = p.SpgText,
        Svarmuligheder = p.Svarmuligheder
    }).Where(q => q.Id == id);

    return nytArray;
});

// POST /api/questions/{id}/validate: Her kan postes et spørgsmåls-id og en svarmulighed,
//                                    og så får man at vide, om svaret er rigtigt eller forkert
app.MapPost("/api/questions/{id}/validate", (int id, SvarMulighed Svaret) => {
    var svarIndex = Quiz.Where(q => q.Id == id).Select(x => x.SvarIndex).First();
    if (Svaret.svar == Quiz[id].Svarmuligheder[svarIndex].ToString())
    {
        return true;
    }
    else
    {
        return false;
    }
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

record SvarMulighed(string svar);

public class SpgIdUdenSvar
{
    public long Id { get; set; }
    public string SpgText { get; set; }
    public string[] Svarmuligheder { get; set; }
}

public class SpgUdenSvar
{
    public string SpgText { get; set; }
    public string[] Svarmuligheder { get; set; }
}

public class Spørgsmål
{
    public long Id { get; set; }
    public string SpgText { get; set; }
    public string[] Svarmuligheder { get; set; }
    public int SvarIndex { get; set; }
}

