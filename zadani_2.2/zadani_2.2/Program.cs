using System;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        using (var db = new NotesContext())
        {
            db.Database.EnsureCreated();
        }

        while (true)
        {
            Console.WriteLine("\n1 - Přidat poznámku");
            Console.WriteLine("2 - Vypsat poznámky");
            Console.WriteLine("3 - Smazat poznámku");
            Console.WriteLine("4 - Konec");
            Console.Write("Volba: ");

            switch (Console.ReadLine())
            {
                case "1": AddNote(); break;
                case "2": ShowNotes(); break;
                case "3": DeleteNote(); break;
                case "4": return;
            }
        }
    }

    static void AddNote()
    {
        Console.Write("Název: ");
        string title = Console.ReadLine();

        Console.Write("Popis: ");
        string desc = Console.ReadLine();

        using var db = new NotesContext();
        db.Notes.Add(new Note { Title = title, Description = desc });
        db.SaveChanges();
    }

    static void ShowNotes()
    {
        using var db = new NotesContext();
        foreach (var n in db.Notes)
        {
            Console.WriteLine($"{n.Id}: {n.Title} – {n.Description}");
        }
    }

    static void DeleteNote()
    {
        Console.Write("ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        using var db = new NotesContext();
        var note = db.Notes.Find(id);
        if (note != null)
        {
            db.Notes.Remove(note);
            db.SaveChanges();
        }
    }
}

class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

class NotesContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=notes.db");
}
