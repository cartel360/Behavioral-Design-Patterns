using System;

// Memento
public class Memento
{
    public string State { get; }

    public Memento(string state)
    {
        State = state;
    }
}

// Originator
public class TextEditor
{
    private string _text = string.Empty;

    public void Write(string text)
    {
        _text = text;
        Console.WriteLine($"Current text: {_text}");
    }

    public Memento Save()
    {
        return new Memento(_text);
    }

    public void Restore(Memento memento)
    {
        _text = memento.State;
        Console.WriteLine($"Restored text: {_text}");
    }
}

// Caretaker
public class Caretaker
{
    private Memento? _memento;

    public void Save(TextEditor editor)
    {
        _memento = editor.Save();
    }

    public void Restore(TextEditor editor)
    {
        if (editor == null) throw new ArgumentNullException(nameof(editor));
        if (_memento == null) throw new InvalidOperationException("No saved state to restore.");
        editor.Restore(_memento);
    }
}

// Client Code
public class Program
{
    public static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();
        Caretaker caretaker = new Caretaker();

        editor.Write("Hello, World!");
        caretaker.Save(editor);

        editor.Write("Hello, Design Patterns!");
        caretaker.Restore(editor);
    }
}