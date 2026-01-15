using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;




Stack<int> ObracenyZasobnik(Stack< int > vstup)
{
    Stack<int> vystup = new Stack<int>();
    foreach(int hodnota in vystup)
    {
        vystup.Push(hodnota);
    }
    return vystup;
}



HashSet<string> PrunikMnozin(HashSet<string> a, HashSet<string> b)
{
    HashSet<string> vysledek = new HashSet<string>();
    foreach(string jmeno in a)
    {
        if (b.Contains(jmeno))
        {
            vysledek.Add(jmeno);
        }
    }

    return vysledek;

}

HashSet<string> m1 = new HashSet<string> { "Kuba", "Eva", "Jan" };
HashSet<string> m2 = new HashSet<string> { "Eva", "Kuba", "Petr" };

HashSet<string> prunik = PrunikMnozin(m1, m2);

Console.WriteLine(string.Join(" ", prunik));
Console.ReadLine();



Dictionary<string, int> PocetVyskytu(Stack<string> zasobnik)
{
    Dictionary<string, int> vysledek = new Dictionary<string, int>();

    while (zasobnik.Count > 0)
    {
        string slovo = zasobnik.Pop();

        if(vysledek.ContainsKey(slovo))
        {
            vysledek[slovo]++;

        }
        else
        {
            vysledek[slovo] = 1;
        }
    }
    return vysledek;
} 


List<int> cisla = new List<int>()
{
    0, 1 ,2 , 3 , 4 , 5 , 6
};
List<int> cisla_delitelna_trema = cisla.Where(x => x %3 == 0 ).ToList();
int delitelnePeti = cisla.First(x => x % 5 == 0);

List<int> mocniny = cisla.Select(x => x * x).ToList();
int soucet = cisla.Aggregate((acc, cur) => acc * cur);
int soucet2 = cisla.Sum(x => x);
