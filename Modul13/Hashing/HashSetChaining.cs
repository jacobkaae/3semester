using Hashing;

public class HashSetChaining : HashSet
{
    private Node[] buckets;
    private int currentSize;

    private class Node
    {
        public Node(Object data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public Object Data { get; set; }
        public Node Next { get; set; }
    }

    public HashSetChaining(int size)
    {
        buckets = new Node[size];
        currentSize = 0;
    }

    public bool Contains(Object x)
    {
        int h = HashValue(x);
        Node bucket = buckets[h];
        bool found = false;
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            else
            {
                bucket = bucket.Next;
            }
        }
        return found;
    }

    public bool Add(Object x)
    {
        int maxSize = (int)Math.Floor(buckets.Length * 0.75);

        if (currentSize >= maxSize)
        {
            Rehash();
        }

        int h = HashValue(x);

        Node bucket = buckets[h];
        bool found = false;
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            else
            {
                bucket = bucket.Next;
            }
        }

        if (!found)
        {
            Node newNode = new Node(x, buckets[h]);
            buckets[h] = newNode;
            currentSize++;
        }

        return !found;
    }

    public void Rehash()
    {
        
        HashSetChaining newArray = new HashSetChaining(buckets.Length * 2);

        for (int i = 0; i < buckets.Length; i++)
        {
            Node temp = buckets[i];

            if (temp != null)
            {
                while (temp != null)
                {
                    newArray.Add(temp.Data);
                    temp = temp.Next;
                }
            }
        }


        buckets = newArray.buckets;

    }
    public
        bool Remove(Object x)
    {
        // TODO: Implement!
        // SKal returnerer true hvis den finder noget at fjerne
        int h = HashValue(x);

        Node node = buckets[h];
        Node previous = null!;
        bool found = false;

        while (!found && node != null)
        {
            if (node.Data.Equals(x))
            {
                found = true;
                if (node == buckets[h])
                {
                    buckets[h] = buckets[h].Next;
                }
                else
                {
                    previous.Next = node.Next;
                }

                currentSize--;
            }
            else
            {
                previous = node;
                node = node.Next;
            }
        }
        return found;
    }

    private int HashValue(Object x)
    {
        int h = x.GetHashCode();
        if (h < 0)
        {
            h = -h;
        }
        h = h % buckets.Length;
        return h;
    }

    public int Size()
    {
        return currentSize;
    }

    public int Length()
    {
        return buckets.Length;
    }

    public override String ToString()
    {
        String result = "";
        for (int i = 0; i < buckets.Length; i++)
        {
            Node temp = buckets[i];
            if (temp != null)
            {
                result += i + "\t";
                while (temp != null)
                {
                    result += temp.Data + " (h:" + HashValue(temp.Data) + ")\t";
                    temp = temp.Next;
                }
                result += "\n";
            }
        }
        return result;
    }
}
