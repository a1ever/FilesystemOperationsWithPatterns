using FilesystemOperations.Exceptions;
using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Entities.Parser.ConcreteHandlers;

public class FileCopyParser : BaseParser
{
    private const int CurrentPosition = 2;
    public FileCopyParser(IGlobalSystem fileSystem)
        : base(fileSystem)
    {
    }

    public override ICommand HandleToCommand(string[] singleRequest)
    {
        IReadOnlyList<ParameterWithValue>? parameters = ParameterParser.Parse(singleRequest);
        return new FileCopy(
            new CommandInformation.FileCopy(
                singleRequest?[CurrentPosition] ?? throw new ParserException(),
                singleRequest?[CurrentPosition + 1] ?? throw new ParserException(),
                parameters),
            FileSystem);
    }
}