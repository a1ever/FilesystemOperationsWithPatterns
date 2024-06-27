using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Commands;

public class Disconnect : ICommand
{
    private readonly CommandInformation.Disconnect _parameters;
    private readonly IGlobalSystem _receiver;

    public Disconnect(CommandInformation.Disconnect parameters, IGlobalSystem receiver)
    {
        _parameters = parameters;
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Disconnect(_parameters);
    }
}