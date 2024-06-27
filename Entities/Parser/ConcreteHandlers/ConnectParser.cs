using FilesystemOperations.Exceptions;
using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Entities.Parser.ConcreteHandlers;

public class ConnectParser : BaseParser
{
    private const int CurrentPosition = 1;
    public ConnectParser(IGlobalSystem fileSystem)
        : base(fileSystem)
    {
    }

    public override ICommand HandleToCommand(string[] singleRequest)
    {
        IReadOnlyList<ParameterWithValue>? parameters = ParameterParser.Parse(singleRequest);
        return new Connect(
            new CommandInformation.Connect(
            singleRequest?[CurrentPosition] ?? throw new ParserException(),
            parameters?[0] ?? new ParameterWithValue("-m", "local"),
            parameters),
            FileSystem);
    }
}