using FilesystemOperations.Exceptions;
using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;

namespace FilesystemOperations.Entities.Parser;

public abstract class BaseParser : IParser
{
    private IParser? _nextParser;

    protected BaseParser(IGlobalSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    protected IGlobalSystem FileSystem { get; }

    public void SetNext(IParser parser)
    {
        _nextParser = parser;
    }

    public virtual ICommand HandleToCommand(string[] singleRequest)
    {
        return _nextParser?.HandleToCommand(singleRequest) ?? throw new ParserException();
    }
}