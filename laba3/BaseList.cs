using System.Collections;

namespace lab1
{
    public abstract class BaseList<T> : IEnumerable<T> where T : IComparable<T>
    {
        public delegate void ListChangedEventHandler(object sender, ActionEventArgs e);

        // События
        public event ListChangedEventHandler ItemAdded;
        public event ListChangedEventHandler ItemInserted;
        public event ListChangedEventHandler ItemDeleted;
        public event ListChangedEventHandler ListCleared;

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

        protected virtual void OnItemAdded(T item)
        {
            ItemAdded?.Invoke(this, new ActionEventArgs("Item Added"));
        }

        protected virtual void OnItemInserted(int pos, T item)
        {
            ItemInserted?.Invoke(this, new ActionEventArgs("Item Inserted at position " + pos));
        }

        protected virtual void OnItemDeleted(int pos)
        {
            ItemDeleted?.Invoke(this, new ActionEventArgs("Item Deleted from position " + pos));
        }

        protected virtual void OnListCleared()
        {
            ListCleared?.Invoke(this, new ActionEventArgs("List Cleared"));
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
            if (Count != otherList.Count)
                return false;

            for (int i = 0; i < Count; i++)
            {
                if (this[i].CompareTo(otherList[i]) != 0)
                    return false;
            }

            return true;
        }
        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine(this[i].ToString());
                }
            }
        }

        public void LoadFromFile(string fileName)
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

        public static bool operator ==(BaseList<T> first, BaseList<T> second)
        {
            return first.IsEqual(second);
        }

        public static bool operator !=(BaseList<T> first, BaseList<T> second)
        {
            return !first.IsEqual(second);
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
        public void AddArrayListEventHandlers()
        {
            ItemAdded += (sender, e) => Console.WriteLine("Элемент был добавлен в ArrayList.");
            ItemInserted += (sender, e) => Console.WriteLine("Элемент был вставлен в ArrayList.");
            ItemDeleted += (sender, e) => Console.WriteLine("Элемент был удален из ArrayList.");
            ListCleared += (sender, e) => Console.WriteLine("ArrayList был очищен.");
        }

        public void AddChainListEventHandlers()
        {
            ItemAdded += (sender, e) => Console.WriteLine("Элемент был добавлен в ChainList.");
            ItemInserted += (sender, e) => Console.WriteLine("Элемент был вставлен в ChainList.");
            ItemDeleted += (sender, e) => Console.WriteLine("Элемент был удален из ChainList.");
            ListCleared += (sender, e) => Console.WriteLine("ChainList был очищен.");
        }
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

    public class ActionEventArgs : EventArgs
    {
        public string Action { get; private set; }

        public ActionEventArgs(string action)
        {
            Action = action;
        }
    }

}
