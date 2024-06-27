using FilesystemOperations.Exceptions;
using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Entities.Parser.ConcreteHandlers;

public class FileShowParser : BaseParser
{
    private const int CurrentPosition = 2;
    public FileShowParser(IGlobalSystem fileSystem)
        : base(fileSystem)
    {
    }

    public override ICommand HandleToCommand(string[] singleRequest)
    {
        IReadOnlyList<ParameterWithValue>? parameters = ParameterParser.Parse(singleRequest);
        return new FileShow(
            new CommandInformation.FileShow(
                singleRequest?[CurrentPosition] ?? throw new ParserException(),
                parameters?[0] ?? throw new ParserException(),
                parameters),
            FileSystem);
    }
}