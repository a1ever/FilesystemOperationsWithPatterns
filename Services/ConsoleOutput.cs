namespace FilesystemOperations.Services;

public class ConsoleOutput : IOutput
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}