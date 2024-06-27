using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Commands;

public class FileCopy : ICommand
{
    private readonly CommandInformation.FileCopy _parameters;
    private readonly IGlobalSystem _receiver;

    public FileCopy(CommandInformation.FileCopy parameters, IGlobalSystem receiver)
    {
        _parameters = parameters;
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.CopyFile(_parameters);
    }
}