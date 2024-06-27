using FilesystemOperations.Models.Filesystem;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Commands;

public class TreeList : ICommand
{
    private readonly CommandInformation.TreeList _parameters;
    private readonly IGlobalSystem _receiver;

    public TreeList(CommandInformation.TreeList parameters, IGlobalSystem receiver)
    {
        _parameters = parameters;
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.WatchCurrentCatalog(_parameters);
    }
}