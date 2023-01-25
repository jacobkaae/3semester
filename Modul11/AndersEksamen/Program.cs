using AndersEksamen;

// Opretter fire bog-objekter til at starte med
Bog bog1 = new Bog { Titel = "Harry Potter #1", Forfatter = "J.K. Rowling", Årstal = 1997, AntalSider = 534 };
Bog bog2 = new Bog { Titel = "Hunger Games", Forfatter = "Suzanne Collins", Årstal = 2008, AntalSider = 350 };
Bog bog3 = new Bog { Titel = "How To Kill a Mockingbird", Forfatter = "Harper Lee", Årstal = 1997, AntalSider = 523 };
Bog bog4 = new Bog { Titel = "Hobitten", Forfatter = "J.R.R. Tolkien", Årstal = 1937, AntalSider = 942 };

// Opretter en tom liste der har typen BogLinkedList
BogLinkedList list = new BogLinkedList();

// Bruger AddLast() funktionen til at tilføje alle bøger
list.AddLast(bog1);
list.AddLast(bog2);
list.AddLast(bog3);
list.AddLast(bog4); // Den her burde altså stå bagerst i listen til sidst

Console.WriteLine($"Test af AddLast(): {list} \n"); // Alle fire bøger burde blive printet her

// Tester RemoveLast() funktionen
// Den burde fjerne bog4 (Hobitten)
list.RemoveLast();

Console.WriteLine($"Test efter brug af RemoveLast(): {list} \n"); // De første tre burde blive printet nu, da vi har fjernet Hobitten (den bagerste)

Console.WriteLine($"Test af AntalBøger() med årstal = 1997: {list.AntalBøger(1997)} \n"); // Burde returnere 2, da vi har to bøger med årstal 1997

Console.WriteLine($"Test af Averagesider(): {list.Averagesider()} \n"); // Returnerer gennemsnittet af sider for de tre bøger, der er tilbage i arrayet
// Burde give 469, da (534+350+523) / 3 = 469. 