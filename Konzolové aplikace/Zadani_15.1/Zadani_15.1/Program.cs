using System;

class Program
{
    static void Main(string[] args)
    {
        // Kontrola argumentů
        if (args.Length != 2)
        {
            Console.WriteLine("Použití: program.exe vstup.txt vysledek.txt");
            return;
        }

        string inputFile = args[0];
        string outputFile = args[1];

        // Zkontrolujeme, zda soubor existuje
        if (!System.IO.File.Exists(inputFile))
        {
            Console.WriteLine("Vstupní soubor nenalezen: " + inputFile);
            return;
        }

        // Načteme celý soubor
        string text = System.IO.File.ReadAllText(inputFile);
        string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        string output = "";

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();

            Console.WriteLine("Zpracovávám řádek: '" + line + "'"); // debug výpis

            // Rozdělíme řádek podle mezer
            string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
            {
                Console.WriteLine("Řádek nemá známky: " + line);
                continue;
            }

            string predmet = parts[0]; // první slovo je předmět

            int soucet = 0;
            int pocet = 0;

            // projdeme zbytek pole = známky
            for (int j = 1; j < parts.Length; j++)
            {
                if (int.TryParse(parts[j], out int znamka))
                {
                    soucet += znamka;
                    pocet++;
                }
                else
                {
                    Console.WriteLine("Neplatná známka: '" + parts[j] + "' v předmětu " + predmet);
                }
            }

            if (pocet > 0)
            {
                double prumer = (double)soucet / pocet;
                output += predmet + ": " + prumer.ToString("0.00") + Environment.NewLine;
            }
        }

        // Zapíšeme výstup do souboru
        System.IO.File.WriteAllText(outputFile, output);

        Console.WriteLine("Hotovo. Výsledek je ve souboru: " + outputFile);
    }
}
