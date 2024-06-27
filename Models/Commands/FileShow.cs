using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Commands;

public class FileShow : ICommand
{
    private readonly CommandInformation.FileShow _parameters;
    private readonly IGlobalSystem _receiver;

    public FileShow(CommandInformation.FileShow parameters, IGlobalSystem receiver)
    {
        _parameters = parameters;
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.ShowFile(_parameters);
    }
}