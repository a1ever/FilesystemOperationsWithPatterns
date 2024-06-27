using FilesystemOperations.Exceptions;
using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Entities.Parser.ConcreteHandlers;

public class TreeGotoParser : BaseParser
{
    private const int CurrentPosition = 2;
    public TreeGotoParser(IGlobalSystem fileSystem)
        : base(fileSystem)
    {
    }

    public override ICommand HandleToCommand(string[] singleRequest)
    {
        IReadOnlyList<ParameterWithValue>? parameters = ParameterParser.Parse(singleRequest);
        return new TreeGoto(
            new CommandInformation.TreeGoto(
                singleRequest?[CurrentPosition] ?? throw new ParserException(),
                parameters),
            FileSystem);
    }
}