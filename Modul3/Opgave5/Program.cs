var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

String[] frugter = new String[]
{
    "æble", "banan", "pære", "ananas"
};

// GET / api / fruit: Returnerer hele frugt-arrayet.
app.MapGet("/api/fruit", () => frugter);

// GET /api/fruit/{index}: Returnerer navnet på en bestemt frugt. Frugten findes i dit frugt-array under index, som er et tal.
app.MapGet("/api/fruit/{index}", (int index) => frugter[index]);

// GET /api/fruit/random: Returnerer navnet på en tilfældig frugt, dvs. en frugt med et tilfældigt index i arrayet.

app.MapGet("/api/fruit/random", () => {

    Random tilfældig = new Random();

    return frugter[tilfældig.Next(frugter.Length)];

});




app.Run();
