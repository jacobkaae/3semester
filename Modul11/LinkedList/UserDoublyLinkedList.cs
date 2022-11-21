namespace DoublyLinkedList
{
    class Node
    {
        public Node(User data, Node previous, Node next)
        {
            this.Data = data;
            this.Previous = previous;
            this.Next = next;
        }

        public User Data;
        public Node Previous;
        public Node Next;
    }

    class UserDoublyLinkedList
    {
        private Node first = null!;
        private Node last = null!;

        public void AddFirst(User user)
        {
            if (first == null)
            {
                Node node = new Node(user, null, null);
                first = node;
                last = node;
            }
            else
            {
                Node node = new Node(user, null, first);
                first.Previous = node;
                first = node;
            }
        }

        public void AddLast(User user)
        {
            if (last == null)
            {
                Node node = new Node(user, null, null);
                first = node;
                last = node;
            }
            else
            {
                Node node = new Node(user, last, null);
                last.Next = node;
                last = node;
            }
        }

        public User RemoveFirst()
        {
            if (first == null)
            {
                return null;
            }
            else
            {
                Node removedNode = first;

                first.Next.Previous = null;
                first = first.Next;

                return removedNode.Data;
            }
        }

        public User RemoveLast()
        {
            if (first == null)
            {
                return null;
            }
            else
            {
                Node removedNode = last;

                last.Previous.Next = null;
                last = last.Previous;

                return removedNode.Data;
            }
        }

        public User GetFirst()
        {
            return first.Data;
        }

        public User GetLast()
        {
            return last.Data;
        }

        public override String ToString()
        {
            Node node = first;
            String result = "";
            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }
            return result.Trim();
        }
    }
}