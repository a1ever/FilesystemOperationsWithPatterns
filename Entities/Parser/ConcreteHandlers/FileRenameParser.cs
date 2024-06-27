using FilesystemOperations.Exceptions;
using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Entities.Parser.ConcreteHandlers;

public class FileRenameParser : BaseParser
{
    private const int CurrentPosition = 2;
    public FileRenameParser(IGlobalSystem fileSystem)
        : base(fileSystem)
    {
    }

    public override ICommand HandleToCommand(string[] singleRequest)
    {
        IReadOnlyList<ParameterWithValue>? parameters = ParameterParser.Parse(singleRequest);
        return new FileRename(
            new CommandInformation.FileRename(
                singleRequest?[CurrentPosition] ?? throw new ParserException(),
                singleRequest?[CurrentPosition + 1] ?? throw new ParserException(),
                parameters),
            FileSystem);
    }
}