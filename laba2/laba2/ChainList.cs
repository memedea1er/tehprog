using System.Globalization;

namespace lab1
{
    public class ChainList : BaseList
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

        public override void Add(int data)
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

        public override void Insert(int pos, int data)
        {
            if (pos < 0 || pos > count)
            {
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

        public override void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
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

        public override void Clear()
        {
            head = null;
            count = 0;
        }

        public override int this[int i]
        {
            get
            {
                Node node = Find(i);
                if (node == null)
                {
                    return 0;
                }
                return node.Data;
            }
            set
            {
                Node node = Find(i);
                if (node == null)
                {
                    return;
                }
                node.Data = value;
            }
        }

        public override void Sort()
        {
            if (count <= 1)
            {
                return;
            }

            int temp;

            for (int i = 0; i < count; i++)
            {
                Node current = head;

                while (current != null & current.Next != null)
                {
                    if (current.Data > current.Next.Data)
                    {
                        temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                    }
                    current = current.Next;
                }
            }
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
        protected override BaseList EmptyClone()
        {
            return new ChainList();
        }
    }
}