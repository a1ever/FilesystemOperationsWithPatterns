using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Commands;

public class FileMove : ICommand
{
    private readonly CommandInformation.FileMove _parameters;
    private readonly IGlobalSystem _receiver;

    public FileMove(CommandInformation.FileMove parameters, IGlobalSystem receiver)
    {
        _parameters = parameters;
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.MoveFile(_parameters);
    }
}