using System;
using System.Collections.Generic;

// Subject interface
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete Subject
public class Stock : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string _stockSymbol;
    private double _price;

    public Stock(string stockSymbol, double price)
    {
        _stockSymbol = stockSymbol;
        _price = price;
    }

    public double Price
    {
        get { return _price; }
        set
        {
            _price = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update(_stockSymbol, _price);
        }
    }
}

// Observer interface
public interface IObserver
{
    void Update(string stockSymbol, double price);
}

// Concrete Observer
public class StockInvestor : IObserver
{
    private string _name;

    public StockInvestor(string name)
    {
        _name = name;
    }

    public void Update(string stockSymbol, double price)
    {
        Console.WriteLine($"Investor {_name} notified: {stockSymbol} price changed to {price}");
    }
}

// Client Code
public class Program
{
    public static void Main(string[] args)
    {
        Stock stock = new Stock("AAPL", 120.0);
        StockInvestor investor1 = new StockInvestor("John");
        StockInvestor investor2 = new StockInvestor("Sarah");

        stock.Attach(investor1);
        stock.Attach(investor2);

        stock.Price = 125.0;
        stock.Price = 130.0;
    }
}