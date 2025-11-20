using System;

void print(params string[] messages)
{
    foreach (string message in messages)
    {
        Console.WriteLine(message);
    }
}





string input(params string[] messages)
{
    print(messages);
    return Console.ReadLine();
}


(int, int) getMinMax(params int[] numbers)
{
    if (numbers.Length == 0) return (0, 0);
    int min = numbers[0];
    int max = numbers[0];
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] < min) min = numbers[i];
        if (numbers[i] > max) max = numbers[i];
    }
    return (min, max); 
}


string name = input("Zadej název souboru");
(int a,int b) = getMinMax(1, 2, 3, 4, 5, 6, 7);
print(name, a.ToString(), b.ToString());