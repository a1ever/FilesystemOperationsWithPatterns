using ICommand = FilesystemOperations.Models.Commands.ICommand;

namespace FilesystemOperations.Entities.Parser;

public interface IParser
{
    public void SetNext(IParser parser);
    public ICommand HandleToCommand(string[] singleRequest);
}