using Hashing;
using System.Xml.Linq;

public interface Map<K, V>
{
    public V Get(K key);
    public V Put(K key, V value);
    public V Remove(K key);
    public bool IsEmpty();
    public int Size();
}

public class HashMap<K, V> : Map<K, V>
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

    public HashMap(int size)
    {
        buckets = new Node[size];
        currentSize = 0;
    }

    public V Put(K key, V value)
    {
        int h = HashValue(key);

        Node bucket = buckets[h];

    }

    private int HashValue(K key)
    {
        int h = key.GetHashCode();

        if (h < 0)
        {
            h = -h;
        }
        h = h % buckets.Length;

        return h;
    }



















    public V Get(K key)
    {
        throw new NotImplementedException();
    }

    public bool IsEmpty()
    {
        throw new NotImplementedException();
    }

   

    public V Remove(K key)
    {
        throw new NotImplementedException();
    }

    public int Size()
    {
        throw new NotImplementedException();
    }
}