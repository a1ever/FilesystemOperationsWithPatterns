using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;

namespace FilesystemOperations.Entities.Parser.ConcreteHandlers;

public class TreeParser : BaseParser
{
    private const int CurrentPosition = 1;
    public TreeParser(IGlobalSystem fileSystem)
        : base(fileSystem)
    {
    }

    public override ICommand HandleToCommand(string[] singleRequest)
    {
        if (singleRequest is null) throw new ArgumentNullException(nameof(singleRequest));

        SetNext(singleRequest[CurrentPosition] switch
        {
            "list" => new TreeListParser(FileSystem),
            "goto" => new TreeGotoParser(FileSystem),
            _ => throw new InvalidDataException(),
        });

        return base.HandleToCommand(singleRequest);
    }
}