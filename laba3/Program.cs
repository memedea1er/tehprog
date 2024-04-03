namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseList<int> array = new ArrayList<int>();
            BaseList<int> chain = new ChainList<int>();
            chain.Add(2);
            chain.Add(1);
            chain.Add(5);
            chain.Add(6);
            chain.Add(4);
            chain.Sort();
            chain.Print();
            Random rnd = new Random();
            //for (int i = 0; i < 15000; i++)
            //{
            //    int operation = rnd.Next(5);
            //    int item = rnd.Next(100);
            //    int pos = rnd.Next(1000);
            //    switch (operation)
            //    {
            //        case 0:
            //            array.Add(item);
            //            chain.Add(item);
            //            break;
            //        case 1:
            //            array.Delete(pos);
            //            chain.Delete(pos);
            //            break;
            //        case 2:
            //            array.Insert(pos, item);
            //            chain.Insert(pos, item);
            //            break;
            //        case 3:
            //            array.Clear();
            //            chain.Clear();
            //            break;
            //        case 4:
            //            array[pos] = item;
            //            chain[pos] = item;
            //            break;
            //    }
            //}
            //bool t = array.Count == chain.Count;
            //if (t)
            //    for (int i = 0; i < chain.Count; i++)
            //        if (array[i] != chain[i])
            //        {
            //            t = false;
            //            break;
            //        }
            //if (!array.IsEqual(chain))
            //    Console.WriteLine("Error");
            //else
            //    Console.WriteLine("Successfull");
            //chain.Add(9);
            //chain.Add(2);
            //chain.Add(3);
            //chain.Add(0);
            //chain.Add(1);
            //BaseList chain2 = chain.Clone();
            //Console.WriteLine(chain.IsEqual(chain2));
            //chain.Print();
            //chain2.Print();
            //chain.Sort();
            //Console.WriteLine(chain.IsEqual(chain2));
            //chain.Print();
            //chain2.Print();
        }
    }
}