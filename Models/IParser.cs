using FilesystemOperations.Models.Commands;

namespace FilesystemOperations.Models;

public interface IParser
{
    ICommand Parse(string command);
}