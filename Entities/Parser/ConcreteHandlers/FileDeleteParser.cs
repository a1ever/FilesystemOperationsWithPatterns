using FilesystemOperations.Exceptions;
using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Entities.Parser.ConcreteHandlers;

public class FileDeleteParser : BaseParser
{
    private const int CurrentPosition = 2;
    public FileDeleteParser(IGlobalSystem fileSystem)
        : base(fileSystem)
    {
    }

    public override ICommand HandleToCommand(string[] singleRequest)
    {
        IReadOnlyList<ParameterWithValue>? parameters = ParameterParser.Parse(singleRequest);
        return new FileDelete(
            new CommandInformation.FileDelete(
                singleRequest?[CurrentPosition] ?? throw new ParserException(),
                parameters),
            FileSystem);
    }
}