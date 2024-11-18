using System;

// Mediator interface
public interface IMediator
{
    void Notify(object sender, string ev);
}

// Concrete Mediator
public class ChatMediator : IMediator
{
    private User? _user1;
    private User? _user2;

    public User User1
    {
        set { _user1 = value; }
    }

    public User User2
    {
        set { _user2 = value; }
    }

    public void Notify(object sender, string ev)
    {
        if (sender == _user1 && _user2 != null)
        {
            Console.WriteLine($"User1 sends: {ev}");
            _user2.Receive(ev);
        }
        else if (sender == _user2 && _user1 != null)
        {
            Console.WriteLine($"User2 sends: {ev}");
            _user1.Receive(ev);
        }
    }
}

// Colleague
public class User
{
    private IMediator _mediator;
    public string Name { get; }

    public User(string name, IMediator mediator)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public void Send(string message)
    {
        _mediator.Notify(this, message);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{Name} received: {message}");
    }
}

// Client Code
public class Program
{
    public static void Main(string[] args)
    {
        ChatMediator mediator = new ChatMediator();

        User user1 = new User("Alice", mediator);
        User user2 = new User("Bob", mediator);

        mediator.User1 = user1;
        mediator.User2 = user2;

        user1.Send("Hello, Bob!");
        user2.Send("Hello, Alice!");
    }
}