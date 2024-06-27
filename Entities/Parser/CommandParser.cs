using FilesystemOperations.Exceptions;
using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;

namespace FilesystemOperations.Entities.Parser;

public class CommandParser
{
    private IGlobalSystem _globalSystem;

    public CommandParser(IGlobalSystem globalSystem)
    {
        _globalSystem = globalSystem;
    }

    public ICommand ParseString(string command)
    {
        return new AnyHandler(_globalSystem).HandleToCommand(command?.Split(' ') ?? throw new ParserException());
    }
}