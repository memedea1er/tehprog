namespace lab1
{
    public abstract class BaseList
    {
        protected int count;

        public int Count
        {
            get { return count; }
        }

        public abstract void Add(int a);

        public abstract void Insert(int pos, int a);

        public abstract void Delete(int pos);

        public abstract void Clear();

        public abstract int this[int i] { get; set; }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(this[i] + " ");
            }
            Console.WriteLine();
        }

        public void Assign(BaseList source)
        {
            Clear();
            for (int i = 0; i < source.count; i++)
            {
                Add(source[i]);
            }
        }

        public void AssignTo(BaseList dest)
        {
            dest.Assign(this);
        }

        public BaseList Clone()
        {
            BaseList clone = EmptyClone();
            clone.Assign(this);
            return clone;
        }

        protected abstract BaseList EmptyClone();

        public virtual void Sort()
        {
            for (int i = 0;i < Count;i++)
            {
                for (int j = i+1;j < Count; j++)
                {
                    if (this[i] > this[j])
                    {
                        int temp = this[i];
                        this[i] = this[j];
                        this[j] = temp;
                    }
                }
            }
        }

        public bool IsEqual(BaseList otherList)
        {
            if (otherList == null)
                return false;

            if (this.Count != otherList.Count)
                return false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] != otherList[i])
                    return false;
            }

            return true;
        }
    }
}