

Console.WriteLine("Euclids: " + Opgave4.Euclids(72, 27));
Console.WriteLine("Potens: " + Opgave4.Potens(3, 2));
Console.WriteLine("Gange: " + Opgave4.Gange(7, 9));
Console.WriteLine("Længde: " + Opgave4.Reverse("BANANKAGE"));

class Opgave4 {

    // Skriv en rekursiv metode der implemeterer Euclids algoritme der finder største fælles divisor af to positive heltal. 
    // Den største fælles divisor af to tal er det største heltal der går op i begge tal.
    public static int Euclids(int a, int b){
        if (b <= a && a % b == 0) {
            return b;
        } else if (a < b) {
            return Euclids(b, a);
        } else {
            return Euclids(b, a%b);
        }
    }

    // Nu skal du lave en rekursiv funktion der opløfter et tal i n’te potens. 
    // Eksempel: Hvis n er 4, skriver man 5⁴ som læses som “5 opløftet til fjerde potens”, og resultatet her er 625.
    public static int Potens(int n, int p) {
        if (n <= 0) {
            return 1;
        } else {
            return p * Potens(n-1, p); 
        }
    }

    // Skriv en rekursiv metode der beregner a * b hvor a og b er to hele tal større end eller lig med nul.
    // Det er ikke tilladt at benytte * i koden til at gange tal sammen. Det hele skal løses rekursivt kun med sammenligninger, + og -.
    public static int Gange(int a, int b) {
        if (a == 1) {
            return b;
        } else if (a == 0 || b == 0) {
            return 0;
        } else {
            return a + Gange(a, b-1);
        }
    }

    // Skriv en rekursiv metode der returnerer s med karaktererne i omvendt rækkefølge.
    // For eksempel skal kaldet Reverse(“EGAKNANAB”) = “BANANAKAGE”.
    public static string Reverse(string bogstaver) {
        int længde = bogstaver.Length;

        if (længde < 1) {
            return "";
        } else {
            return bogstaver.Substring(længde-1) + Reverse(bogstaver.Substring(0, længde-1));
        }
    }
}