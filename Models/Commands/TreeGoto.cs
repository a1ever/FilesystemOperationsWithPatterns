using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Commands;

public class TreeGoto : ICommand
{
    private readonly CommandInformation.TreeGoto _parameters;
    private readonly IGlobalSystem _receiver;

    public TreeGoto(CommandInformation.TreeGoto parameters, IGlobalSystem receiver)
    {
        _parameters = parameters;
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.SystemGoTo(_parameters);
    }
}