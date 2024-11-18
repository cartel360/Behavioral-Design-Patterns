using System;

// Abstract Class
public abstract class DataProcessor
{
    public void Process()
    {
        ReadData();
        ProcessData();
        WriteData();
    }

    protected abstract void ReadData();
    protected abstract void ProcessData();
    protected abstract void WriteData();
}

// Concrete Class for XML
public class XmlDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading XML data...");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Processing XML data...");
    }

    protected override void WriteData()
    {
        Console.WriteLine("Writing XML data...");
    }
}

// Concrete Class for JSON
public class JsonDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading JSON data...");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Processing JSON data...");
    }

    protected override void WriteData()
    {
        Console.WriteLine("Writing JSON data...");
    }
}

// Client Code
public class Program
{
    public static void Main(string[] args)
    {
        DataProcessor xmlProcessor = new XmlDataProcessor();
        xmlProcessor.Process();

        DataProcessor jsonProcessor = new JsonDataProcessor();
        jsonProcessor.Process();
    }
}