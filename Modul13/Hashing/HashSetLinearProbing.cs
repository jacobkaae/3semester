using System.Xml.Linq;
using Hashing;

public class HashSetLinearProbing : HashSet
{
    private Object[] buckets;
    private int currentSize;
    private enum State { DELETED }

    public HashSetLinearProbing(int bucketsLength)
    {
        buckets = new Object[bucketsLength];
        currentSize = 0;
    }

    public bool Contains(Object x)
    {
        // TODO: Implement!
        int h = HashValue(x);
        int start = HashValue(x);

        bool found = false;

        while (!found && buckets[h] != null)
        {
            if (buckets[h].Equals(x))
            {
                found = true;
            }
            else
            {
                h = (h + 1) % buckets.Length;

                if (h == start)
                {
                    return false;
                }
            }
        }

        return found;
    }

    public bool Add(Object x)
    {
        // TODO: Implement!
        int h = HashValue(x);
        int start = HashValue(x);

        bool succes = false;


        while (!succes)
        {
            if (buckets[h] == null)
            {
                buckets[h] = x;
                succes = true;
                currentSize++;
            } else
            {
                h = (h + 1) % buckets.Length;

                if (h == start)
                {
                    return false;
                }
            }
        }

        return succes;
    }

    public bool Remove(Object x)
    {
        // TODO: Implement!
        if (buckets.Contains(x))
        {
            int h = HashValue(x);
            bool found = false;

            while (!found)
            {
                if (buckets[h].Equals(x))
                {
                    buckets[h] = State.DELETED;
                    currentSize--;
                    found = true;
                }
                else
                {
                    h = (h + 1) % buckets.Length;
                }
            }
            return true;
        }
        return false;
    }


    public int Size()
    {
        return currentSize;
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

    public override String ToString()
    {
        String result = "";
        for (int i = 0; i < buckets.Length; i++)
        {
            int value = buckets[i] != null && !buckets[i].Equals(State.DELETED) ?
                    HashValue(buckets[i]) : -1;
            result += i + "\t" + buckets[i] + "(h:" + value + ")\n";
        }
        return result;
    }

}
