/*void print(params string[] messages) // definice funkce
{
    foreach (string message in messages)
    {
        Console.WriteLine(message);
    }
}
 
string input(params string[] messages)
{
    foreach (string message in messages)
    {
        Console.WriteLine(message);
    }
    return Console.ReadLine();
}
 
(int, int) getMinMax(params int[] numbers){
    int min = numbers[0];
    int max = numbers[0];
    for (int i = 1; i < numbers.Length;  i++)
    {
        if (numbers[i] < min) min = numbers[i];
        if (numbers[i] > max) max = numbers[i];
    }
    return (min, max);
}
*/
/*
double vypocet(double zakladna, double vyska)
{
    double s = 0.5 * zakladna * vyska;
    return s;
}
 
double zakladna = 12;
double vyska = 3;
 
double vysledek = vypocet(zakladna, vyska);
 
Console.WriteLine(vysledek);
*/
/*string FormatujCislo(double cislo)
{
    string text = cislo.ToString();
    string[] casti = text.Split(',');
    string celaCast = casti[0];
    string desetinna = "";
    if (casti.Length > 1)
    {
        desetinna = casti[1];
    string vysledek = "";
    for (int i = celaCast.Length -1; i>=0; i--)
        {
            vysledek = celaCast[i] + vysledek;
            if ((celaCast.Length - 1) % 3 == 0)
            {
                vysledek = " " + vysledek;
            }
            return vysledek + "," + desetinna;
        }
    }
    return $"cela cast: {celaCast}, desetinna cast {desetinna}";
}
 
Console.WriteLine(FormatujCislo(1356.7819)); // vypisuje 6.7819 ale proc?
*/


/*
(int min, int max) = getMinMax(1, 2, 4, 5, 6, 7);
 
string name = input("zadej nazev souboru");
print(name, min.ToString(), max.ToString());
 
//print("Ahoj", "Ahoj 2", "Ahoj 3"); //spusteni funkce*/

/*
string input1 = Console.ReadLine();
 
string[] array = input1.Split(",");
 
string input2 = Console.ReadLine();
for (int i = 0; i < array.Length; i++)
{
    if (input1 == input2)
    {
        Console.WriteLine("they are the same string");
    }
    else
    {
        Console.WriteLine("they are different");
    }
}
*/
/*
int pocetOdlisnychZnaku(string jedna, string dva)
{
    int length = Math.Min(jedna.Length, dva.Length);
    int count = 0;
    for (int i = 0; i < length; i++)
    {
        if (jedna[i] != dva[i])
        {
            count++;
        }
    }
    count += Math.Abs(jedna.Length - dva.Length);
    return count;
}
 
int vysledek = pocetOdlisnychZnaku("abcdef", "abc");
Console.WriteLine(vysledek);
*/
/*
string changeFirstLetter(string veta)
{
    string[] slova = veta.Split(" ");
    if (slova.Length != 2)
    {
        return veta;
    }
    return slova[1] + " " + slova[0];
}
Console.WriteLine(changeFirstLetter("Hello World"));
*/




int CifernySoucet(int cislo)
{
    int res = 0;
    while(cislo > 0)
    {
        res += cislo % 10;
        cislo /= 10;
    }
    return res;

}


bool JePalindrom(string slovo)
{
    
    string s = slovo.ToLower().Replace(" ", "");

    
    char[] chars = s.ToCharArray();
    Array.Reverse(chars);
    string obracene = new string(chars);

    return s == obracene;
}


Console.WriteLine(JePalindrom("kajak"));   
Console.WriteLine(JePalindrom("auto"));



List<double> GetPositiveValues(double[] numbers)
{
    List<double> positives = new List<double>();
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > 0)
        {
            positives.Add(numbers[i]);
        }
    }
    return positives;
}


T Vetsi<T>(T jedna, T dva) where T : IComparable
{
    if (jedna.CompareTo(dva) > 0)
        return dva; 
    return jedna;
}

string vetsitext = Vetsi("123", "456");
int vetsiCislo = Vetsi(123, 456);


Action<string> a = (text) => 
{
    Console.WriteLine(text) ;
};

a("ahoj");
a?.Invoke("ahoj");

Func<int, string> f = (text) =>
{
    return text.Lenght;

};