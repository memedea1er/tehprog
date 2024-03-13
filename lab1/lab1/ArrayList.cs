using System;

namespace lab1
{
    public class ArrayList
    {
        private int[] array;
        private int count;

        public ArrayList()
        {
            array = new int[0];
            count = 0;
        }

        public void Add(int a)
        {
            EnsureCapacity();
            array[count] = a;
            count++;
        }

        public void Insert(int a, int pos)
        {
            if (pos < 0 || pos > count)
            {
                //System.Environment.Exit(0);
                return;
            }

            EnsureCapacity();

            for (int i = count; i > pos; i--)
            {
                array[i] = array[i - 1];
            }

            array[pos] = a;
            count++;
        }

        public void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                //System.Environment.Exit(0);
                return;
            }

            for (int i = pos; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }

            count--;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
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
                if (i < 0 || i >= count)
                {
                    //System.Environment.Exit(0);
                    return 0;
                }

                return array[i];
            }
            set
            {
                if (i < 0 || i >= count)
                {
                    //System.Environment.Exit(0);
                    return;
                }

                array[i] = value;
            }
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public bool UniqueСheck()
        {
            if (count <= 1)
                return true;
            for (int i = 0;i < count - 1;i++)
            {
                for(int j = i + 1;j < count;j++)
                {
                    if (array[i] == array[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void EnsureCapacity()
        {
            if (count == array.Length)
            {
                int[] temp;
                if (array.Length == 0)
                {
                    temp = new int[2];
                }
                else
                {
                    temp = new int[array.Length * 2];
                }
                for (int i = 0; i < array.Length; i++)
                {
                    temp[i] = array[i];
                }
                array = temp;
            }
        }
    }
}