namespace Laphed.DataStructures
{
    public class CircularList<TData>
    {
        public TData Current => current.Data;
        private Node current;
        private Node head;
        private Node tail;

        public void Add(TData data)
        {
            Node newNode = new Node(data);
                
            if (head == null)
            {
                head = newNode;
                head.Next = head;
                tail = head;
                current = head;
                return;
            }

            tail.Next = newNode;
            newNode.Next = head;
        }

        public TData Next()
        {
            TData data = current.Next.Data;
            current = current.Next;
            return data;
        }

        private class Node
        {
            public TData Data { get; set; }
            public Node Next { get; set; }

            public Node(TData data)
            {
                this.Data = data;
            }
        }
    }
}