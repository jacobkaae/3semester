// Skriv en rekursiv metode der beregner n!, også kaldet for “n fakultet”. 
// Termineringsregel: 0! = 1
// Rekurrensregel: n! = n * (n - 1)! hvor n > 0.

Console.WriteLine(Opgave3.Faculty(5)); // Output skal være '120'.
class Opgave3 {
    public static int Faculty(int n) {
       
        if (n == 1) {
            return 1;
        } else {
            return n * Faculty(n-1); 
        }
    }
}