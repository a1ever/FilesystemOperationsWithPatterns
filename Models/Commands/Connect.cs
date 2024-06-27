using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Commands;

public class Connect : ICommand
{
    private readonly CommandInformation.Connect _parameters;
    private readonly IGlobalSystem _receiver;

    public Connect(CommandInformation.Connect parameters, IGlobalSystem receiver)
    {
        _parameters = parameters;
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Connect(_parameters);
    }
}