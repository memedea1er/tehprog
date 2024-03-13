namespace lab1
{
    public class ArrayList : BaseList
    {
        private int[] array;

        public ArrayList()
        {
            array = new int[0];
            count = 0;
        }

        public override void Add(int a)
        {
            EnsureCapacity();
            array[count] = a;
            count++;
        }

        public override void Insert(int pos, int a)
        {
            if (pos < 0 || pos > count)
            {
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

        public override void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                return;
            }

            for (int i = pos; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }

            count--;
        }

        public override void Clear()
        {
            Array.Resize(ref array, 0);
            count = 0;
        }

        public override int this[int i]
        {
            get
            {
                if (i < 0 || i >= count)
                {
                    return 0;
                }

                return array[i];
            }
            set
            {
                if (i < 0 || i >= count)
                {
                    return;
                }

                array[i] = value;
            }
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
        protected override BaseList EmptyClone()
        {
            return new ArrayList();
        }
    }
}