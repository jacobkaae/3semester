using AltIEn.Data;
using AltIEn.Model;
using AltIEn.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Sætter CORS så API'en kan bruges fra andre domæner
var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSomeStuff, builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Tilføj DbContext factory som service.
builder.Services.AddDbContext<RetContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ContextSQLite")));

// Tilføj DataService så den kan bruges i endpoints
builder.Services.AddScoped<DataService>();

// Dette kode kan bruges til at fjerne "cykler" i JSON objekterne.
builder.Services.Configure<JsonOptions>(options =>
{
    // Her kan man fjerne fejl der opstår, når man returnerer JSON med objekter,
    // der refererer til hinanden i en cykel.
    // (altså dobbelrettede associeringer)
    options.SerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddAuthentication("DummyAuthentication")
                .AddScheme<AuthenticationSchemeOptions, DummyAuthenticationHandler>("DummyAuthentication", null);

builder.Services.AddAuthorization(options => {
    options.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin"));
});
builder.Services.AddHttpContextAccessor();




var app = builder.Build();

// Seed data hvis nødvendigt.
using (var scope = app.Services.CreateScope())
{
    var dataService = scope.ServiceProvider.GetRequiredService<DataService>();
    dataService.SeedData(); // Fylder data på, hvis databasen er tom. Ellers ikke.
}

app.UseHttpsRedirection();
app.UseCors(AllowSomeStuff);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Middleware der kører før hver request. Sætter ContentType for alle responses til "JSON".
app.Use(async (context, next) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    await next(context);
});

app.MapGet("/", () => "Hello World!");

// Hent alle retter
app.MapGet("/retter", (DataService service) =>
{
    return service.GetRetter();
});

// Hent alle ingredienser
app.MapGet("/ingredienser", [Authorize(Policy = "Admin")] (DataService service) =>
{
    return service.GetIngredienser();
});

// POST /ingredienser - Laver en ny ingrediens
app.MapPost("/ingredienser", [Authorize(Policy = "Admin")] (DataService service, Ingrediens ingrediens) =>
{
    Ingrediens nyIngrediens = new Ingrediens
    {
        Navn = ingrediens.Navn
    };

    string results = service.AddIngrediens(nyIngrediens);

    return new { message = results };
});

app.Run();
