
class Program
{
    static void Main()
    {
        //Testy programu i możliwe zastosowania

        //------------------------------------------------------------------------Int---------------------------------

        Kontroler<int> intController = new Kontroler<int>();

        intController.ItemAdded += ItemAdded;
        
        intController.Add(15);
        intController.Add(8);
        intController.Add(9);
        intController.Add(2);
        intController.Add(22);
        intController.Add(14);

        Console.WriteLine(); 

        Console.WriteLine("Orginalna lista");
        DisplayItems(intController);
        Console.WriteLine();
        Console.WriteLine("Posortowana od największego do najmniejszego");
        intController.Sort((x, y) => x.CompareTo(y));
        DisplayItems(intController);
        Console.WriteLine();
        Console.WriteLine("Posortowana od najmniejszego do największego");
        intController.Sort((x, y) => y.CompareTo(x));
        DisplayItems(intController);
        Console.WriteLine();
        Console.WriteLine("Po filtrowaniu => 12");
        intController.Filter(x => x > 12);
        DisplayItems(intController);

        //------------------------------------------------------------------------String---------------------------------

        Kontroler<string> stringController = new Kontroler<string>();
        stringController.ItemAdded += ItemAdded;
        Console.WriteLine(); Console.WriteLine();

        stringController.Add("gruszka");
        stringController.Add("banan");
        stringController.Add("kapusta");
        Console.WriteLine();
        Console.WriteLine("Lista przed usunięciem:");
        DisplayItems(stringController);

        stringController.Delete("banan");

        Console.WriteLine("\nLista po usunięciu \"banana\":");
        DisplayItems(stringController);

        //------------------------------------------------------------------------Pair---------------------------------

        Console.WriteLine(); Console.WriteLine();
        List<Pair<int, string>> pairs = new List<Pair<int, string>>
        {
            new Pair<int, string>(3, "gruszka"),
            new Pair<int, string>(1, "kapusta"),
            new Pair<int, string>(2, "banan")
        };

        Console.WriteLine("Przed sortwaniem");
        foreach (var pair in pairs)
        {
            Console.WriteLine($"Pierwsza wartość: {pair.First}, Druga wartość: {pair.Second}");
        }

        pairs.Sort();

        Console.WriteLine(); Console.WriteLine();

        Console.WriteLine("Po sortowaniu");

        foreach (var pair in pairs)
        {
            Console.WriteLine($"Pierwsza wartość: {pair.First}, Druga wartość: {pair.Second}");
        }


        static void ItemAdded<T>(object sender, ItemAddedEventArgs<T> e)
        {
            Console.WriteLine($"Dodano nowy element: {e.Item}");
        }

        static void DisplayItems<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}



