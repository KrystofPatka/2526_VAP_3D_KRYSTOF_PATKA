namespace Tridy;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Nedostatečný počet argumentů");
            return;
        }
        string operation = args[0].ToLower().Trim();
        string title = args[1];
        bool completed = args[2].ToLower().Trim() == "splneno";
        if (operation == "pridat")
        {
            string[] lines = File.ReadAllLines("tasks.txt");
            Dictionary<int, MyTask> tasks = ParseFile(lines);
            MyTask task = new MyTask(title, completed);
            tasks.Add(task.Id, task);
            File.WriteAllLines("tasks.txt", TasksToString(tasks));
            break;
            case "zobrazit":
                foreach (MyTask myTask in tasks.Values)
                {
                    Console.WriteLine(myTask);
                }
                break;
            case "odstranit":
                if (args.Lenght < 2)
                {
                    Console.WriteLine("Nedostatečný počet argumentů");
                    return;

                }
                try
                {
                    int id = int.Parse(args[1]);
                    bool isCompleted = args[2].Trim().ToLower() == "splneno";
                    MyTask removed = tasks[id];
                    tasks.Remove(id);
                    Console.WriteLine("Byla odstraněna úloha: " + removed);
                    File.WriteAllLines("tasks.txt", TasksToString(tasks));
                }
                catch
                {
                    Console.WriteLine("Neexistujici id ulohy");
                }

        }  
    }
    // Metoda pro převod slovníku s úlohami na textový řetězec
    static List<string> TasksToString(Dictionary<int, MyTask> tasks)
    {
        List<string> result = new List<string>();
        foreach (MyTask value in tasks.Values) 
        {
            result.Add(value.ToString());
        }
        return result;
    }

    // Metoda pro převod řádků textu na slovník s úlohami
    static Dictionary<int, MyTask> ParseFile(string[] lines)
    {
        Dictionary<int, MyTask> dictionary = new Dictionary<int, MyTask>();

        foreach (string line in lines)
        {
            try
            {
                string[] parts = line.Split(",");
                string title = parts[0].Split(":")[1].Trim();
                string completed = parts[1].Split(":")[1].Trim();
                string id = parts[2].Split(":")[1].Trim();
                MyTask task = new MyTask(title, bool.Parse(completed), int.Parse(id));
                dictionary.Add(task.Id, task);
            } catch { }  
        }
        return dictionary;
    }
}
