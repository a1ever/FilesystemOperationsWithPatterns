using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Commands;

public class FileRename : ICommand
{
    private readonly CommandInformation.FileRename _parameters;
    private readonly IGlobalSystem _receiver;

    public FileRename(CommandInformation.FileRename parameters, IGlobalSystem receiver)
    {
        _parameters = parameters;
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.RenameFile(_parameters);
    }
}