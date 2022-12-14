Person[] people = new Person[]
{
    new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
    new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
    new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
    new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
    new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
    new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
};


// Find og udskriv personen med mobilnummer “+4543215687”.
var mobilNummer = people.Where(p => p.Phone == "+4543215687").First();
Console.WriteLine(mobilNummer.Name);


// Vælg alle som er over 30 og udskriv dem.
var over30 = people.Where(p => p.Age > 30);
foreach (Person person in over30)
{
    Console.WriteLine(person.Name);
}


// Lav et nyt array med de samme personer, men hvor “+45” er fjernet fra alle telefonnumre.
var nytArray = people.Select(p => new Person
{
    Name = p.Name,
    Age = p.Age,
    Phone = p.Phone.Substring(3, 8)
}).ToArray();


// Generér en string med navn og telefonnummer på de personer, der er yngre end 30, adskilt med komma
var under30 = people.Where(p => p.Age < 30).ToArray();
Console.WriteLine("Personer under 30 år: " + Person.Under30String(under30));

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }

    public static string Under30String(Person[] array)
    {
        if (array.Length == 0)
        {
            return ".";
        } else {
            return $" {array[0].Name} er {array[0].Age} år gammel," + Under30String(array.Skip(1).ToArray());
        }
    }
}