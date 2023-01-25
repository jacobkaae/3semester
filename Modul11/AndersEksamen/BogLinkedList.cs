using AndersEksamen;

// Opretter en klasse der har bøger som data
class Node
{
    public Bog Data;

    public Node Next;

    public Node(Bog data, Node next)
    {
        this.Data = data;
        this.Next = next;
    }

}


// Opretter en LinkedList-klasse der indeholder Nodes
class BogLinkedList
{

    private Node first = null!;

    // Returnerer void og tager en bog som input. Tilføjer bogen i slutningen af linkedlist
    public void AddLast(Bog bog)
    {
        Node node = first;

        if (first == null)
        {
            first = new Node(bog, null);
        }
        else
        {
            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = new Node(bog, null);
        }
    }

    // Returnerer void og tager ingenting som input. Fjerner den sidste bog i linkedlist
    public void RemoveLast()
    {
        Node node = first;

        if (first == null)
        {
            return;
        }
        else
        {
            while (node.Next.Next != null)
            {
                node = node.Next;
            }

            node.Next = null;
        }

    }

    // Returnerer en int og tager en int (årstal) som input. Tæller antal bøger der har det årstal
    public int AntalBøger(int årstal)
    {
        Node node = first;

        int antal = 0;

        if (first == null)
        {
            return antal;
        }
        else
        {
            while (node != null)
            {
                if (node.Data.Årstal == årstal)
                {
                    antal++;
                }

                node = node.Next;
            }

            return antal;
        }

    }

    // Returnerer en int og tager ingenting som input. Tæller alle sider for alle bøger og regner gennemsnittet ud for antal sider pr. bog.
    // Dette returneres herefter. 
    public int Averagesider()
    {
        Node node = first;

        // Tælle-variabler for antal sider i alt og antal bøger i alt 
        int antalSiderSum = 0;
        int antalBøger = 0;

        if (first == null)
        {
            return antalSiderSum;
        }
        else
        {
            while (node != null)
            {
                antalSiderSum += node.Data.AntalSider;

                antalBøger++;

                node = node.Next;
            }
            // Bruger tællevariablerne til at returnere gennemsnittet
            return antalSiderSum / antalBøger;
        }
    }

    // En funktiom der gør, at når vi bruger Console.Writeline(), får vi en liste af bøgernes navne
    // (Jeg har bare kopieret den her funktion fra UserLinkedList opgaven)
    public override String ToString()
    {
        Node node = first;
        String result = "";
        while (node != null)
        {
            string punktering = node.Next != null ? ", " : ".";
            result += node.Data.Titel + punktering;
            node = node.Next;
        }
        return result.Trim();
    }

}


