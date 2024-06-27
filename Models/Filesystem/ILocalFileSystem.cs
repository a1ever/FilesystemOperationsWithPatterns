using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Filesystem;

public interface ILocalFileSystem
{
    public string Name { get; }

    public void Connect(CommandInformation.Connect connect);
    public void SystemGoTo(CommandInformation.TreeGoto command);
    public void WatchCurrentCatalog(CommandInformation.TreeList command);
    public void ShowFile(CommandInformation.FileShow command);
    public void MoveFile(CommandInformation.FileMove command);
    public void CopyFile(CommandInformation.FileCopy command);
    public void DeleteFile(CommandInformation.FileDelete command);
    public void RenameFile(CommandInformation.FileRename command);
}