// I denne opgave skal du lave følgende to Højere Ordens Funktioner:

// CreateWordFilterFn: Funktionen skal returnere en ny funktion. 
// Den nye funktion tager en tekst som input, fjerner alle ord der matcher et ord i “words”, 
// og returnerer en tekst hvor ordene er fjernet.

var CreateWordFilterFn = (string[] words) =>
{
    return (string tekst) =>
    {
        return tekst = tekst
            .Replace(words[0], "");
    };
};

var ord = new string[] { "Hej", "Med", "Dig" };
var vedIk = CreateWordFilterFn(ord);
Console.WriteLine("Test:" + vedIk("Ok, Hej med dig Morten"));