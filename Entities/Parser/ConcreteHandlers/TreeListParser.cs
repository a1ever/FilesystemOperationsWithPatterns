using FilesystemOperations.Exceptions;
using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Entities.Parser.ConcreteHandlers;

public class TreeListParser : BaseParser
{
    public TreeListParser(IGlobalSystem fileSystem)
        : base(fileSystem)
    {
    }

    public override ICommand HandleToCommand(string[] singleRequest)
    {
        IReadOnlyList<ParameterWithValue>? parameters = ParameterParser.Parse(singleRequest);
        return new TreeList(
            new CommandInformation.TreeList(
                parameters?[0] ?? throw new ParserException(),
                parameters),
            FileSystem);
    }
}