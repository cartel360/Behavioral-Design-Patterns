using System;

// State interface
public interface IState
{
    void Handle(Context context);
}

// Concrete State A
public class HappyState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("In a happy state!");
        context.SetState(new SadState());
    }
}

// Concrete State B
public class SadState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("In a sad state!");
        context.SetState(new HappyState());
    }
}

// Context
public class Context
{
    public required IState State { get; set; }

    public void SetState(IState state)
    {
        State = state ?? throw new ArgumentNullException(nameof(state));
    }

    public void Request()
    {
        State.Handle(this);
    }
}

// Client Code
public class Program
{
    public static void Main(string[] args)
    {
        Context context = new Context { State = new HappyState() };

        context.SetState(new HappyState());
        context.Request();

        context.Request();
    }
}