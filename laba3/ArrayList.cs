
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
        }

        public override void Insert(int pos, T a)
        {
            try
            {
                if (pos < 0 || pos > count)
                {
                    ExceptionCounter.IncrementArrayExceptionCount();
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
            catch (BadIndexException)
            {
                ExceptionCounter.IncrementArrayExceptionCount();
                return;
            }
        }

        public override void Delete(int pos)
        {
            try
            {
                if (pos < 0 || pos >= count)
                {
                    ExceptionCounter.IncrementArrayExceptionCount();
                    return;
                }
                for (int i = pos; i < count - 1; i++)
                {
                    array[i] = array[i + 1];
                }

                count--;
            }
            catch (BadIndexException)
            {
                ExceptionCounter.IncrementArrayExceptionCount();
                return;
            }
        }

        public override void Clear()
        {
            Array.Resize(ref array, 0);
            count = 0;
        }

        public override T this[int i]
        {
            get
            {
                try
                {
                    if (i < 0 || i >= count)
                    {
                        ExceptionCounter.IncrementArrayExceptionCount();
                        return default(T);
                    }
                    return array[i];
                }
                catch (BadIndexException)
                {
                    ExceptionCounter.IncrementArrayExceptionCount();
                    return default(T);
                }
            }
            set
            {
                try
                {
                    if (i < 0 || i >= count)
                    {
                        ExceptionCounter.IncrementArrayExceptionCount();
                        return;
                    }
                    array[i] = value;
                }
                catch (BadIndexException)
                {
                    ExceptionCounter.IncrementArrayExceptionCount();
                    return;
                }
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
