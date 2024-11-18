using System;

// Strategy interface
public interface ICompressionStrategy
{
    void Compress(string fileName);
}

// Concrete Strategy A
public class ZipCompression : ICompressionStrategy
{
    public void Compress(string fileName)
    {
        Console.WriteLine($"Compressing {fileName} using Zip.");
    }
}

// Concrete Strategy B
public class RarCompression : ICompressionStrategy
{
    public void Compress(string fileName)
    {
        Console.WriteLine($"Compressing {fileName} using Rar.");
    }
}

// Context
public class FileCompressor
{
    private ICompressionStrategy _compressionStrategy;

    public FileCompressor(ICompressionStrategy compressionStrategy)
    {
        _compressionStrategy = compressionStrategy;
    }

    public void SetStrategy(ICompressionStrategy compressionStrategy)
    {
        _compressionStrategy = compressionStrategy;
    }

    public void CompressFile(string fileName)
    {
        _compressionStrategy.Compress(fileName);
    }
}

// Client Code
public class Program
{
    public static void Main(string[] args)
    {
        FileCompressor fileCompressor = new FileCompressor(new ZipCompression());
        fileCompressor.CompressFile("example.txt");

        fileCompressor.SetStrategy(new RarCompression());
        fileCompressor.CompressFile("example.txt");
    }
}