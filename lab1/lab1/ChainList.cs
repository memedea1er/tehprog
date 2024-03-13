using System;

namespace lab1
{
    public class ChainList
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node(int data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node head = null;
        private int count = 0;

        public void Add(int data)
        {
            if (head == null)
            {
                head = new Node(data, null);
            }
            else
            {
                Node lastNode = Find(count - 1); 
                lastNode.Next = new Node(data, null); 
            }
            count++;
        }

        public void Insert(int data, int pos)
        {
            if (pos < 0 || pos > count)
            {
                //System.Environment.Exit(0);
                return;
            }

            if (pos == 0)
            {
                head = new Node(data, head);
            }
            else
            {
                Node prev = Find(pos - 1);
                prev.Next = new Node(data, prev.Next);
            }
            count++;
        }

        public void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                //System.Environment.Exit(0);
                return;
            }

            if (pos == 0)
            {
                head = head.Next;
            }
            else
            {
                Node prev = Find(pos - 1);
                prev.Next = prev.Next.Next;
            }
            count--;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public int this[int i]
        {
            get
            {
                Node node = Find(i);
                if (node == null)
                {
                    //System.Environment.Exit(0);
                    return 0;
                }
                return node.Data;
            }
            set
            {
                Node node = Find(i);
                if (node == null)
                {
                    //System.Environment.Exit(0);
                    return;
                }
                node.Data = value;
            }
        }

        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public bool UniqueСheck()
        {
            if (count <= 1)
                return true;
            for (int i = 0; i < count - 1; i++)
            {
                Node current = Find(i);
                int c = current.Data;
                for (int j = i + 1; j < count; j++)
                {
                    current = current.Next;
                    if (c == current.Data)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private Node Find(int pos)
        {
            if (pos >= count)
            {
                return null;
            }

            int i = 0;
            Node p = head;
            while (p != null && i < pos)
            {
                p = p.Next;
                i++;
            }

            if (i == pos)
            {
                return p;
            }
            else
            {
                return null;
            }
        }
    }
}
