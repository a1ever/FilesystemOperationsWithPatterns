using FilesystemOperations.Entities.Parser;
using FilesystemOperations.Models.Filesystem;

namespace FilesystemOperations;

public static class Program
{
    public static void Main()
    {
        
        var parser = new CommandParser(new GlobalSystem(new WindowsFileSystem("Main")));
        var x = Console.ReadLine();
        while (x is not null)
        {
            parser.ParseString(x).Execute(); 
            x = Console.ReadLine();
        }
    }
}