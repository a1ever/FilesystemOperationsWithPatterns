using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Filesystem;

public interface IReceiverConnect
{
    void DefaultConnect(CommandInformation.Connect parameters);
}