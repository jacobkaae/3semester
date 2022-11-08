// Opgave 2: Opfind en fjollet algoritme for at gå op af alle trappetrinene fra kantinen og op til dit lokale,
//           som kører med en worst case udførselstid udtrykt ved O(n²).


int[] SortedArray { get; set; } =
          new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

int next = 0;


static int[] InsertSorted(int tal)
{
    // TODO: Implement!

    int min = 0;
    int max = sortedArray.Length - 1;
    int insertFelt;

    while (min <= max)
    {
        int mid = min + (min + max) / 2;

        if (tal == sortedArray[mid])
        {
            insertFelt = mid + 1;
        }
        else if (tal < sortedArray[mid])
        {
            max = mid - 1;
        }
        else if (tal > sortedArray[mid])
        {
            min = mid + 1;

        }
        else
        {
            insertFelt = min;
        }
    }