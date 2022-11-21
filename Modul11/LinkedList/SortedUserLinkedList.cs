namespace LinkedList
{
    class SortedUserLinkedList
    {
        private Node first = null!;

        public void Add(User user)
        {
            if (first == null || user.Id < first.Data.Id)
            {
                Node node = new Node(user, first);
                first = node;
            }
            else
            {
                Node node = first;
                Node previous = null;

                while (node.Next != null && node.Data.Id < user.Id)
                {
                    previous = node;
                    node = node.Next;
                }

                Node newNode = new Node(user, node);
                if (node == first)
                {
                    first = newNode;
                }
                else
                {
                    previous.Next = newNode;
                }

            }
        }

        public User GetFirst()
        {
            return first.Data;
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