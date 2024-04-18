using System.Collections;

namespace lab1
{
    using System;


    class Program
    {
        static void Main(string[] args)
        {
            BaseList<char> array = new ArrayList<char>();
            BaseList<char> chain = new ChainList<char>();

            array.AddArrayListEventHandlers();
            chain.AddChainListEventHandlers();

            Random random = new Random();
            int arrExCount = 0;
            int linkedExCount = 0;

            for (int i = 0; i < 1000; i++)
            {
                int operation = random.Next(1, 6);
                char Data = (char)('a' + random.Next(0, 26));
                int index = random.Next(0, 50);

                switch (operation)
                {
                    case 1:
                        array.Add(Data);
                        chain.Add(Data);
                        break;

                    case 2:
                        try
                        {
                            array.Delete(index);
                        }
                        catch (BadIndexException)
                        {
                            arrExCount++;
                            Console.WriteLine("Поймано исключение в Delete");
                        }
                        try
                        {
                            chain.Delete(index);
                        }
                        catch (BadIndexException)
                        {
                            linkedExCount++;
                            Console.WriteLine("Поймано исключение в Delete");

                        }
                        break;

                    case 3:
                        try
                        {
                            array.Insert(index, Data);
                        }
                        catch (BadIndexException)
                        {
                            arrExCount++;
                            Console.WriteLine("Поймано исключение в Insert");
                        }
                        try
                        {
                            chain.Insert(index, Data);
                        }
                        catch (BadIndexException)
                        {
                            linkedExCount++;
                            Console.WriteLine("Поймано исключение в Insert");
                        }
                        break;

                    case 4:
                        array.Clear();
                        chain.Clear();
                        break;

                    case 5:
                        try
                        {
                            array[index] = Data;
                        }
                        catch (BadIndexException)
                        {
                            arrExCount++;
                            Console.WriteLine("Поймано исключение в Set");
                        }
                        try
                        {
                            chain[index] = Data;
                        }
                        catch (BadIndexException)
                        {
                            linkedExCount++;
                            Console.WriteLine("Поймано исключение в Set");
                        }
                        break;
                }
            }

            if (array.IsEqual(chain))
            {
                Console.WriteLine("\nTest success\nArrayList такой же как и ChainList\n");
            }
            else
            {
                Console.WriteLine("\nTest error\nArrayList НЕ такой же как и ChainList\n");
            }

            Console.WriteLine("Элементы ArrayList: ");
            array.Print();
            string filename = "test_lab3.txt";
            array.SaveToFile(filename);
            BaseList<char> clone = array.Clone();
            Console.WriteLine($"Считывание с файла {filename}:");
            clone.LoadFromFile(filename);
            clone.Print();

            Console.WriteLine("Проверка оператора '=='");
            if (array == chain) { Console.WriteLine("ArrayList = ChainList\n"); }
            else { Console.WriteLine("ArrayList != ChainListn\n"); }

            Console.WriteLine("Проверка оператора '!='");
            if (array != chain) { Console.WriteLine("ArrayList != ChainList\n"); }
            else { Console.WriteLine("ArrayList = ChainList\n"); }

            Console.WriteLine("Проверка оператора '+'");
            clone.Clear();
            clone = array + chain;
            clone.Print();

            Console.WriteLine($"Кол-во исключений в ArrayList: {arrExCount}\nКол-во исключений в ChainList: {linkedExCount}");
        }
    }
}
