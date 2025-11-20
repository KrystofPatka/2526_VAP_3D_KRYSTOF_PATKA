


using System;
using System.Collections.Generic;

class ProgramUkol
{
    static void Main()
    {
        Console.Write("Zadej výraz: ");
        string input = Console.ReadLine();

        string[] parts = input.Split(' ');
        List<string> list = new List<string>();

        double current = double.Parse(parts[0]);

        for (int i = 1; i < parts.Length; i += 2)
        {
            string op = parts[i];
            double num = double.Parse(parts[i + 1]);

            if (op == "*")
                current *= num;
            else if (op == "/")
                current /= num;
            else
            {
                list.Add(current.ToString());
                list.Add(op);
                current = num;
            }
        }

        list.Add(current.ToString());

        double vysledek = double.Parse(list[0]);

        for (int i = 1; i < list.Count; i += 2)
        {
            string op = list[i];
            double num = double.Parse(list[i + 1]);

            if (op == "+") vysledek += num;
            else vysledek -= num;
        }

        Console.WriteLine("Výsledek: " + vysledek);

        Console.ReadLine();
    }
}
