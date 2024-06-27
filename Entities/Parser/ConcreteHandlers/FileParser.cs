using FilesystemOperations.Models.Commands;
using FilesystemOperations.Models.Filesystem;

namespace FilesystemOperations.Entities.Parser.ConcreteHandlers;

public class FileParser : BaseParser
{
    private const int CurrentPosition = 1;
    public FileParser(IGlobalSystem fileSystem)
        : base(fileSystem)
    {
    }

    public override ICommand HandleToCommand(string[] singleRequest)
    {
        if (singleRequest is null) throw new ArgumentNullException(nameof(singleRequest));

        SetNext(singleRequest[CurrentPosition] switch
        {
            "show" => new FileShowParser(FileSystem),
            "move" => new FileMoveParser(FileSystem),
            "copy" => new FileCopyParser(FileSystem),
            "delete" => new FileDeleteParser(FileSystem),
            "rename" => new FileRenameParser(FileSystem),
            _ => throw new InvalidDataException(),
        });
        return base.HandleToCommand(singleRequest);
    }
}