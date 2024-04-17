
using System;
using System.Reflection;

namespace lab1
{
    public class ArrayList<T> : BaseList<T> where T : IComparable<T>
    {
        private T[] array;

        public ArrayList()
        {
            array = new T[0];
            count = 0;
        }

        public override void Add(T a)
        {
            EnsureCapacity();
            array[count] = a;
            count++;
            OnItemAdded(a);
        }

        public override void Insert(int pos, T a)
        {
            if (pos < 0 || pos > count)
            {
                throw new BadIndexException();
            }
            EnsureCapacity();

            for (int i = count; i > pos; i--)
            {
                array[i] = array[i - 1];
            }

            array[pos] = a;
            count++;
            OnItemInserted(pos, a);
        }

        public override void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                throw new BadIndexException();
            }
            for (int i = pos; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            count--;
            OnItemDeleted(pos);
        }

        public override void Clear()
        {
            Array.Resize(ref array, 0);
            count = 0;
            OnListCleared();
        }

        public override T this[int i]
        {
            get
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException();
                }
                return array[i];
            }
            set
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException();
                }
                array[i] = value;
            }
        }

        private void EnsureCapacity()
        {
            if (count == array.Length)
            {
                T[] temp;
                if (array.Length == 0)
                {
                    temp = new T[2];
                }
                else
                {
                    temp = new T[array.Length * 2];
                }
                for (int i = 0; i < array.Length; i++)
                {
                    temp[i] = array[i];
                }
                array = temp;
            }
        }

        protected override BaseList<T> EmptyClone()
        {
            return new ArrayList<T>();
        }

        public override string ToString()
        {
            return string.Join(" ", array);
        }
    }
}
