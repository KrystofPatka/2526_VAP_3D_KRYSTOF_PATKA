using System;
using System.Collections.Generic;

class Funkce
{
    public static string PrumernaRychlost(double vzdalenostKm, double casMin)
    {
        if (vzdalenostKm < 0 || casMin < 0)
        {
            return "Neplatné hodnoty";
        }

        if (casMin == 0)
        {
            if (vzdalenostKm > 0)
                return "Nelze vypočítat (dělení nulou)";
            else
                return "Průměrná rychlost: 0,00 km/h";
        }

        double casHodiny = casMin / 60.0;
        double prumer = vzdalenostKm / casHodiny;

        return $"Průměrná rychlost: {prumer} km/h";
    }



    public static int PocetSamohlasek(string text)
    {
        if (string.IsNullOrEmpty(text))
            return 0;


        string samohlasky = "aeiouyáéěíóúůý";
        int pocet = 0;

        foreach (char c in text.ToLower())
        {
            if (samohlasky.Contains(c))
                pocet++;
        }

        return pocet;
    }

    public static List<int> ZpracovaniPole(int[] pole)
    {
        List<int> list = new List<int>();

        if (pole == null)
            return list;

        foreach (int cislo in pole)
        {
            if (cislo >= 0 && !list.Contains(cislo))
                list.Add(cislo);
        }

        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[j] < list[i])
                {
                    int tmp = list[i];
                    list[i] = list[j];
                    list[j] = tmp;
                }
            }

        }
        return list;


    }

 }


class Program 
{

    static void Main()
    {
        Console.WriteLine(Funkce.PrumernaRychlost(10, 30));
        Console.WriteLine(Funkce.PocetSamohlasek("Ahoj lidi tady Honza Tymeš"));

        var list = Funkce.ZpracovaniPole(new int[] { 3, -1, 3, 0, 5, 8, 2, 9}); 
        Console.WriteLine("[" + string.Join(", ", list) + "]");

    }

}

