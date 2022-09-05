using System;

Person[] people = new Person[]
{
    new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
    new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
    new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
    new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
    new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
    new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
};

// Højere ordens funktion
var CreateSorter = (Func<Person, Person, int> compareFn) =>
{
    {
        return (Person[] array) =>
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    // Laver en ombytning, hvis to personer står forkert sorteret
                    if (compareFn(array[j], array[j + 1]) > 0)
                    {
                        BubbleSort.Swap(array, j, j + 1);
                    }
                }
            }

            return array;

        };
    }

};

// Der laves en ny sorterings-funktion hvor der sammenlignes på alder
var PeopleSortAge = CreateSorter((person1, person2) => person1.Age - person2.Age);

// Der laves en ny sorterings-funktion hvor der sammenlignes på name
var PeopleSortName = CreateSorter((person1, person2) => person1.Name.CompareTo(person2.Name));

// Der laves en ny sorterings-funktion hvor der sammenlignes på telefonnummer
var PeopleSortPhone = CreateSorter((person1, person2) => person1.Phone.CompareTo(person2.Phone));



// Den nye funktion bruges til at sortere et array
var sortedPeople = PeopleSortPhone(people);

// Det sorterede array udskrives med LINQ så vi kan se at det virker
sortedPeople.ToList().ForEach(p => Console.WriteLine(p.Phone.Substring(3) + " " + p.Name));



public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}

public class BubbleSort
{
    // Bytter om på to elementer i et array
    public static void Swap(Person[] array, int i, int j)
    {
        Person temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

}