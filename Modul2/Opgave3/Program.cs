// I denne opgave skal du lave følgende to Højere Ordens Funktioner:

// CreateWordFilterFn: Funktionen skal returnere en ny funktion. 
// Den nye funktion tager en tekst som input, fjerner alle ord der matcher et ord i “words”, 
// og returnerer en tekst hvor ordene er fjernet.

var CreateWordFilterFn = (string[] words) =>
{
    return (string tekst) =>
    {
        words.ToList().ForEach(p => tekst = tekst.Replace(p, ""));

        return tekst;
    };
};

//var ord = new string[] { "Hej", "Med", "Dig" };

//var vedIk = CreateWordFilterFn(ord);

//Console.WriteLine("Test:" + vedIk("Goddag, Hej Med Dig Jacob"));


// CreateWordReplacerFn: Funktionen skal returnere en ny funktion.
// Den nye funktion tager en tekst som input, erstatter alle ord der matcher et ord i “words” med “replacementWord”, og returnerer den nye tekst.


var CreateWordReplacerFn = (string[] words, string replacementWord) =>
{
    return (string tekst) =>
    {
        words.ToList().ForEach(p => tekst = tekst.Replace(p, replacementWord));

        return tekst;
    };
};

var badWords = new string[] { "tis", "pis", "lort" };

var FilterBadWords = CreateWordReplacerFn(badWords, "banan");

Console.WriteLine(FilterBadWords("Sikke en gang pis lort"));

