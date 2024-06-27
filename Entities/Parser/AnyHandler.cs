using FilesystemOperations.Entities.Parser.ConcreteHandlers;
using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;

namespace FilesystemOperations.Entities.Parser;

public class AnyHandler : BaseParser
{
    public AnyHandler(IGlobalSystem fileSystem)
        : base(fileSystem)
    {
    }

    public override ICommand HandleToCommand(string[] singleRequest)
    {
        if (singleRequest is null) throw new ArgumentNullException(nameof(singleRequest));

        SetNext(singleRequest[0] switch
        {
            "tree" => new TreeParser(FileSystem),
            "file" => new FileParser(FileSystem),
            "connect" => new ConnectParser(FileSystem),
            "disconnect" => new DisconnectParser(FileSystem),
            _ => throw new InvalidDataException(),
        });

        return base.HandleToCommand(singleRequest);
    }
}