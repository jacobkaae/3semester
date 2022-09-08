using System;

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
Random tilfældig = new Random();

app.MapGet("/api/fruit/random", () => frugter[tilfældig.Next(frugter.Length)]);


// Du skal nu tilføje en POST som kan sende nye frugter til frugt-API’en.
// POST /api/fruit: Tilføjer en ny frugt til arrayet.
app.MapPost("/api/fruit", (Fruit frugt) => {

    if (string.IsNullOrEmpty(frugt.name))
    {
        // Returnerer Status 400 
        return Results.BadRequest();

    } else {
        frugter = frugter.Append(frugt.name).ToArray();

        Console.WriteLine($"Tilføjet frugt: {frugt.name}");

        // Returnerer Status 200
        return Results.Ok(frugter);
    }
    }

);



app.Run();

record Fruit(string name);

