namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            ChainList chain = new ChainList();

            Random rnd = new Random();
            for (int i = 0; i < 15000; i++)
            {
                int operation = rnd.Next(5);
                int item = rnd.Next(100);
                int pos = rnd.Next(1000);
                switch (operation)
                {
                    case 0:
                        array.Add(item);
                        chain.Add(item);
                        break;
                    case 1:
                        array.Delete(pos);
                        chain.Delete(pos);
                        break;
                    case 2:
                        array.Insert(pos, item);
                        chain.Insert(pos, item);
                        break;
                    //case 3:
                    //    array.Clear();
                    //    chain.Clear();
                    //    break;
                    case 4:
                        array[pos] = item;
                        chain[pos] = item;
                        break;
                }
            }
            //    array.Add(3);

            bool t = array.Count == chain.Count;
            if (t)
                for (int i = 0; i < chain.Count; i++)
                    if (array[i] != chain[i])
                    {
                        t = false;
                        break;
                    }
            if (!t)
                Console.WriteLine("Error");
            else
                Console.WriteLine("Successfull");
            array.Add(1);
            array.Add(2);
            chain.Add(1);
            chain.Add(1);
            Console.WriteLine(array[1]);
            Console.WriteLine(array.UniqueСheck());
            Console.WriteLine(chain.UniqueСheck());
        }
    }
}