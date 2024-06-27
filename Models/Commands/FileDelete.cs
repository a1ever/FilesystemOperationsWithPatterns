using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Commands;

public class FileDelete : ICommand
{
    private readonly CommandInformation.FileDelete _parameters;
    private readonly IGlobalSystem _receiver;

    public FileDelete(CommandInformation.FileDelete parameters, IGlobalSystem receiver)
    {
        _parameters = parameters;
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.DeleteFile(_parameters);
    }
}