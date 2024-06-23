using System;

class Program
{
    static void Main()
    {
        string[] salespeople = { "Danielle", "Edward", "Francis" };
        char[] initials = { 'D', 'E', 'F' };
        double[] sales = new double[salespeople.Length];
        string input;

        while (true)
        {
            Console.WriteLine("Enter salesperson initial (D, E, F) or Z to quit:");
            input = Console.ReadLine().ToUpper();

            if (input == "Z")
            {
                break;
            }

            int index = Array.IndexOf(initials, input[0]);
            if (index == -1)
            {
                Console.WriteLine("Error, invalid salesperson selected, please try again");
                continue;
            }

            Console.WriteLine("Enter sale amount:");
            if (double.TryParse(Console.ReadLine(), out double saleAmount) && saleAmount >= 0)
            {
                sales[index] += saleAmount;
            }
            else
            {
                Console.WriteLine("Error, invalid sale amount entered, please try again");
            }
        }

        double grandTotal = 0;
        for (int i = 0; i < sales.Length; i++)
        {
            grandTotal += sales[i];
        }

        int topSalespersonIndex = GetTopSalespersonIndex(sales);

        for (int i = 0; i < salespeople.Length; i++)
        {
            Console.WriteLine($"Total sales for {salespeople[i]} ({initials[i]}): ${sales[i]}");
        }
        Console.WriteLine($"Grand Total: ${grandTotal}");
        Console.WriteLine($"Highest Sale: {initials[topSalespersonIndex]}");
    }

    static int GetTopSalespersonIndex(double[] sales)
    {
        int topIndex = 0;
        for (int i = 1; i < sales.Length; i++)
        {
            if (sales[i] > sales[topIndex])
            {
                topIndex = i;
            }
        }
        return topIndex;
    }
}
