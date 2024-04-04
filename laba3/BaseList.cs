using System.Collections;

namespace lab1
{
    public abstract class BaseList<T> : IEnumerable<T> where T : IComparable<T>
    {
        protected int count;

        public int Count
        {
            get { return count; }
        }

        public abstract void Add(T a);

        public abstract void Insert(int pos, T a);

        public abstract void Delete(int pos);

        public abstract void Clear();

        public abstract T this[int i] { get; set; }

        public void Print()
        {
            foreach (var a in this)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
        }

        public void Assign(BaseList<T> source)
        {
            Clear();
            for (int i = 0; i < source.count; i++)
            {
                Add(source[i]);
            }
        }

        public void AssignTo(BaseList<T> dest)
        {
            dest.Assign(this);
        }

        public BaseList<T> Clone()
        {
            BaseList<T> clone = EmptyClone();
            clone.Assign(this);
            return clone;
        }

        protected abstract BaseList<T> EmptyClone();

        public virtual void Sort()
        {
            for (int i = 0; i < Count; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (this[i].CompareTo(this[j]) > 0)
                    {
                        T temp = this[i];
                        this[i] = this[j];
                        this[j] = temp;
                    }
                }
            }
        }

        public bool IsEqual(BaseList<T> otherList)
        {
            if (otherList == null)
                return false;

            if (this.Count != otherList.Count)
                return false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].CompareTo(otherList[i]) != 0)
                    return false;
            }

            return true;
        }
        public void SaveToFile(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteLine(this[i].ToString());
                    }
                }
            }
            catch (BadFileException)
            {
                ExceptionCounter.IncrementChainExceptionCount();
                return;
            }
        }

        public void LoadFromFile(string fileName)
        {
            try
            {
                Clear();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Trim() != "")
                        {
                            T item = (T)Convert.ChangeType(line, typeof(T));
                            Add(item);
                        }
                    }
                }
            }
            catch (BadFileException)
            {
                ExceptionCounter.IncrementChainExceptionCount();
                return;
            }
        }

        public static bool operator ==(BaseList<T> first, BaseList<T> second)
        {
            return first.IsEqual(second);
        }

        public static bool operator !=(BaseList<T> first, BaseList<T> second)
        {
            return!first.IsEqual(second);
        }

        public static BaseList<T> operator +(BaseList<T> first, BaseList<T> second)
        {
            BaseList<T> list = first.Clone();
            for (int i = 0; i < second.Count; i++)
            {
                list.Add(second[i]);
            }
            return list;
        }
        public class BadIndexException : Exception
        {
            public BadIndexException() : base("exception")
            {
            }
        }

        public class BadFileException : Exception
        {
            public BadFileException() : base("exception")
            {
            }
        }

        public class ExceptionCounter
        {
            protected static int ChainExceptioncount = 0;
            protected static int ArrayExceptioncount = 0;

            public static int ChainExceptionCount { get { return ChainExceptioncount; } }
            public static int ArrayExceptionCount { get { return ArrayExceptioncount; } }

            public static void IncrementChainExceptionCount()
            {
                ChainExceptioncount++;
            }

            public static void IncrementArrayExceptionCount()
            {
                ArrayExceptioncount++;
            }
        }

        public class ActionEventArgs : EventArgs
        {
            public string Action { get; private set; }

            public ActionEventArgs(string action)
            {
                Action = action;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new BaseListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class BaseListEnumerator : IEnumerator<T>
        {
            private BaseList<T> list;
            private int currentIndex = -1;

            public BaseListEnumerator(BaseList<T> list)
            {
                this.list = list;
            }

            public T Current => list[currentIndex];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < list.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose()
            {
                // Метод Dispose не требуется в этом примере, но интерфейс IDisposable реализуется для соответствия
            }
        }
    }
}
