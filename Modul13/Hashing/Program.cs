using Hashing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

HashSet names = new HashSetLinearProbing(13);

names.Add("Romeo");
names.Add("Harry");
names.Add("Sue");
names.Add("Nina");
names.Add("Susannah");
names.Add("Larry");
names.Add("Eve");
names.Add("Sarah");
names.Add("Adam");
names.Add("Tony");
names.Add("Katherine");
names.Add("Juliet");

Console.WriteLine(names);

Console.WriteLine("Size: "+names.Size());

Console.WriteLine("Contains Romeo: " + names.Contains("Romeo"));
names.Remove("Romeo");
Console.WriteLine("Contains Romeo: " + names.Contains("Romeo"));

names.Remove("Nina");
Console.WriteLine("Contains Nina: " + names.Contains("Nina"));

Console.WriteLine("Size: " + names.Size());
Console.WriteLine();
Console.WriteLine(names);



