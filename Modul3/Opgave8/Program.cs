using Microsoft.EntityFrameworkCore;
using Opgave8.Model;

var builder = WebApplication.CreateBuilder(args);

var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskContextSQLite")));

var app = builder.Build();
app.UseCors(AllowCors);

// GET /api/tasks
app.MapGet("/api/tasks", (TaskContext db) =>
{
    return db.Tasks;
});

// GET /api/tasks/{id}
app.MapGet("/api/tasks/{id}", (int id, TaskContext db) =>
{
    return db.Tasks.Where(p => p.TaskId == id);
});

// PUT /api/tasks/{id}
app.MapPut("/api/tasks/{id}", (int id, Opgave8.Model.Task opdTask, TaskContext db) =>
{
    var dbTask = db.Tasks
        .Where(x => x.TaskId == id)
        .First();

    dbTask.Text = opdTask.Text;
    dbTask.Done = opdTask.Done;

    db.SaveChanges();
    //return Huskeliste = Huskeliste.Select(x =>
    //{
    //    if (x.Id == id)
    //    {
    //        x = opdTask;
    //        x.Id = id;
    //        return x;
    //    }
    //    else
    //    {
    //        return x;
    //    }
    //}).ToArray();

    // Best practice
    //return Huskeliste = Huskeliste.Select(x => x.Id == id ? opdTask : x).ToArray();

});


// DELETE /api/tasks/{id}
app.MapDelete("/api/tasks/{id}", (int id, TaskContext db) =>
{
    var sletTask = db.Tasks
        .Where(x => x.TaskId == id)
        .First();

    db.Remove(sletTask);
    return db.SaveChanges();
});


// POST /api/tasks/
app.MapPost("/api/tasks", (Opgave8.Model.Task nyTask, TaskContext db) =>
{
    db.Add(new Opgave8.Model.Task(nyTask.Text, nyTask.Done));
    return db.SaveChanges();
});

app.Run();



