using EF_sjov.Model;

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");

    // Create
    Console.WriteLine("Indsæt et nyt task");
    db.Add(new TodoTask("Gør rent", false, "Oprydning", new User("Jacob")));
    db.SaveChanges();

    // Read
    //Console.WriteLine("Find det sidste task");
    //var lastTask = db.Tasks
    //    .OrderBy(b => b.TodoTaskId)
    //    .Last();
    //Console.WriteLine($"Text: {lastTask.Text}");

    // Update
    //Console.WriteLine("Find en task og opdater den, indtast id: ");
    //int id = Int32.Parse(Console.ReadLine());
    //var update = db.Tasks
    //        .Where(x => x.TodoTaskId == id)
    //        .First();
    //Console.WriteLine("Indtast ny text:");
    //update.Text = Console.ReadLine();
    //db.SaveChanges();
    //Console.WriteLine("Opdateret!");

    //// Delete
    //Console.WriteLine("Find en task og slet den, indtast text:");
    //string text = Console.ReadLine();
    //var delete = db.Tasks
    //        .Where(x => x.Text == text);

    //foreach (var item in delete)
    //{
    //    db.Remove(item);
    //}
    //db.SaveChanges();

    //Console.WriteLine("Slettet!");


}