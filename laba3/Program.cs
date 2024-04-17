namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int arr_count_except = 0;
            int chain_count_except = 0;
            BaseList<char> array = new ArrayList<char>();
            BaseList<char> chain = new ChainList<char>();

            /*array.Add(0);
            array.Add(1);
            array.Add(2);
            Console.WriteLine(array.Duplicate());
            array.Add(0);
            Console.WriteLine(array.Duplicate());

            chain.Add(0);
            chain.Add(1);
            chain.Add(2);
            Console.WriteLine(chain.Duplicate());
            chain.Add(0);
            Console.WriteLine(chain.Duplicate());*/

            Random rnd = new Random();
            for (int i = 0; i < 15000; i++)
            {
                int operation = rnd.Next(5);
                char item = (char)('a' + rnd.Next(0, 26));
                int pos = rnd.Next(100);
                switch (operation)
                {
                    case 0:
                        array.Add(item);
                        chain.Add(item);
                        break;
                    case 1:
                        try
                        {
                            array.Delete(pos);
                        }
                        catch (BadIndexException)
                        {
                            arr_count_except++;
                        }
                        try
                        {
                            chain.Delete(pos);
                        }
                        catch (BadIndexException)
                        {
                            chain_count_except++;
                        }
                        break;
                    case 2:
                        try
                        {
                            array.Insert(pos, item);
                        }
                        catch (BadIndexException)
                        {
                            arr_count_except++;
                        }
                        try
                        {
                            chain.Insert(pos, item);
                        }
                        catch (BadIndexException)
                        {
                            chain_count_except++;
                        }
                        break;
                    case 3:
                        array.Clear();
                        chain.Clear();
                        break;
                    case 4:
                        try
                        {
                            array[pos] = item;
                        }
                        catch (BadIndexException)
                        {
                            arr_count_except++;
                        }
                        try
                        {
                            chain[pos] = item;
                        }
                        catch (BadIndexException)
                        {
                            chain_count_except++;
                        }
                        break;
                }
            }

            bool flag = true;
            if (array.Count == chain.Count)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    if (array[i] != chain[i])
                    {
                        Console.WriteLine("Test error");
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Test error");
                flag = false;
            }
            if (flag == true)
            {
                Console.WriteLine("Test successfull");
            }

            /*Console.WriteLine("\nTesting Clone method:");

            array.Clear();
            array.Add(1);
            array.Add(2);
            array.Add(3);

            BaseList<int> arrListClone = array.Clone();

            chain.Clear();
            chain.Add(1);
            chain.Add(2);
            chain.Add(3);

            BaseList<int> chainListClone = chain.Clone();

            if (chainListClone.IsEqual(chain) && arrListClone.IsEqual(array))
            {
                Console.WriteLine("Clone successfull");
            }
            else
            {
                Console.WriteLine("Clone error");
            }

            Console.WriteLine("\nTesting Assign method:");

            array.Clear();
            array.Add(1);
            array.Add(2);
            array.Add(3);

            chain.Clear();
            chain.Add(4);
            chain.Add(5);
            chain.Add(6);

            array.Assign(chain);

            if (chain.IsEqual(array))
            {
                Console.WriteLine("Assign successfull");
            }
            else
            {
                Console.WriteLine("Assign error");
            }


            Console.WriteLine("\nTesting AssignTo method:");

            array.Clear();
            array.Add(1);
            array.Add(2);
            array.Add(3);

            chain.Clear();
            chain.Add(4);
            chain.Add(5);
            chain.Add(6);

            chain.AssignTo(array);

            if (chain.IsEqual(array))
            {
                Console.WriteLine("AssignTo successfull");
            }
            else
            {
                Console.WriteLine("AssignTo error");
            }

            Console.WriteLine("\nTesting Sort method");
            array.Clear();
            array.Add(3);
            array.Add(10);
            array.Add(1);
            array.Add(0);
            array.Add(26);
            array.Add(7);

            chain.Clear();
            chain.Add(3);
            chain.Add(10);
            chain.Add(1);
            chain.Add(0);
            chain.Add(26);
            chain.Add(7);

            array.Sort();
            chain.Sort();

            if (chain.IsEqual(array))
            {
                Console.WriteLine("Sort successfull");
            }
            else
            {
                Console.WriteLine("Sort error");
            }*/

            Console.WriteLine(arr_count_except);
            Console.WriteLine(chain_count_except);
        }
    }
}
