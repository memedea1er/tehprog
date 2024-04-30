
using System;
using System.Reflection;

namespace lab1
{
    public class ChainList<T> : BaseList<T> where T : IComparable<T>
    {
        public class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node head = null;

        public override void Add(T data)
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
            OnItemChanged();
        }

        public override void Insert(int pos, T data)
        {
            if (pos < 0 || pos >= count)
            {
                throw new BadIndexException();
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
            OnItemChanged();
        }

        public override void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                throw new BadIndexException();
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
            OnItemChanged();
        }

        public override void Clear()
        {
            head = null;
            count = 0;
            OnItemChanged();
        }

        public override T this[int i]
        {
            get
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException();
                }
                Node node = Find(i);
                return node.Data;
            }

            set
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException();
                }
                Node current = Find(i);
                current.Data = value;
            }
        }

        public override void Sort()
        {
            if (count <= 1)
            {
                return;
            }

            T temp;

            while (true)
            {
                bool t = true;
                Node current = head;

                while (current != null && current.Next != null)
                {
                    if (current.Data.CompareTo(current.Next.Data) > 0)
                    {
                        temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        t = false;
                    }
                    current = current.Next;
                }
                if (t)
                {
                    break;
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

        protected override BaseList<T> EmptyClone()
        {
            return new ChainList<T>();
        }

        public override string ToString()
        {
            string result = "";
            Node current = head;
            while (current != null)
            {
                result += current.Data.ToString() + " ";
                current = current.Next;
            }
            return result.Trim();
        }
    }
}
