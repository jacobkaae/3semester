// Læs metoden igennem og forstå princippet i løsningen.
// Input 'path' er den mappe man starter i
// Opgave5.ScanDir("/Users/jacobkaae/Desktop/3semester/Modul1");
Console.WriteLine(Opgave5.ScanDirCount("C:/Users/Jacob/Desktop/3semester/Modul1/Opgave2"));
class Opgave5
{
    public static void ScanDir(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();

        // Udskriver alle filerne
        foreach (FileInfo file in files)
        {
            Console.WriteLine(file.Name);
        }
        DirectoryInfo[] dirs = dir.GetDirectories();

        // Kalder rekursivt på alle undermapper
        foreach (DirectoryInfo subdir in dirs)
        {
            ScanDir(subdir.FullName);
        }
    }

    // Lav en ny rekursiv løsning der gennemløber en mappe og tæller antal mapper i stedet for at udskrive dem. 
    // Metoden kunne hedde public static int ScanDirCount(String path).
    public static int ScanDirCount(string path)
    {
        int antal = 0;
        DirectoryInfo dir = new DirectoryInfo(path);
        DirectoryInfo[] dirs = dir.GetDirectories();

        if (dirs == null)
        {
            return 0;
        }
        else
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                return dirs.Count() + ScanDirCount(subdir.FullName);
            }

            return antal;
        }
    }
}