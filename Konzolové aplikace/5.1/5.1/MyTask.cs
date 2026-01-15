using System.Text;

class MyTask
{
    private static int _count = 0;
    public string Title;
    public bool Completed;
    public int Id;

    public MyTask(string title, bool completed)
    {
        Title = title;
        Completed = completed;
        Id = _count++;
    }

    public MyTask(string title, bool completed, int id)
    {
        Title = title;  
        Completed = completed;
        Id = id;
        _count = Math.Max(0, _count);
    }
}

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
            MyTask task = new MyTask(title, completed);
            string[] lines = File.ReadAllLines("tasks.txt");
            File.WriteAllText("tasks.txt", task.ToString());
        }
    }

    static string TasksToString(Dictionary<int, MyTask> tasks)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var pair in tasks)
        {
            MyTask task = pair.Value;
            sb.AppendLine($"Title: {task.Title}, Completed: {task.Completed}, Id: {task.Id}");
        }

        return sb.ToString();
    }

    Dictionary<int, MyTask> ParseFile(string[] lines)
    {
        Dictionary<int, MyTask> dictionary = new Dictionary<int, MyTask>();

        foreach (string line in lines)
        {

            string[] parts = lines[0].Split(",");
            string title = parts[0].Split(":")[1].Trim();
            string completed = parts[1].Split(":")[1].Trim();
            string id = parts[2].Split(":")[1].Trim();
            MyTask task = new MyTask(title, bool.Parse(completed), int.Parse(id));
            dictionary.Add(task.Id, task);
        }
        return dictionary;

    }
}








