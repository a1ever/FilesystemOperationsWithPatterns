using FilesystemOperations.Exceptions;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Models.Filesystem;

public class GlobalSystem : IGlobalSystem
{
    private readonly List<ILocalFileSystem> _fileSystems;
    private ILocalFileSystem? _currentFileSystem;

    public GlobalSystem(params ILocalFileSystem[] fileSystems)
    {
        _fileSystems = fileSystems.ToList();
    }

    public void Connect(CommandInformation.Connect parameters)
    {
        if (_currentFileSystem is not null) throw new ConnectException("Already connected");
        _currentFileSystem = _fileSystems.FirstOrDefault(x => x.Name == parameters.Mode.Value) ?? throw new ConnectException();
        _currentFileSystem.Connect(parameters);
    }

    public void Disconnect(CommandInformation.Disconnect parameters)
    {
        if (_currentFileSystem is null) throw new ConnectException("Already disconnected");
        _currentFileSystem = null;
    }

    public void SystemGoTo(CommandInformation.TreeGoto command)
    {
        if (_currentFileSystem is null) throw new NotConnectedException();
        _currentFileSystem.SystemGoTo(command);
    }

    public void WatchCurrentCatalog(CommandInformation.TreeList command)
    {
        if (_currentFileSystem is null) throw new NotConnectedException();
        _currentFileSystem.WatchCurrentCatalog(command);
    }

    public void ShowFile(CommandInformation.FileShow command)
    {
        if (_currentFileSystem is null) throw new NotConnectedException();
        _currentFileSystem.ShowFile(command);
    }

    public void MoveFile(CommandInformation.FileMove command)
    {
        if (_currentFileSystem is null) throw new NotConnectedException();
        _currentFileSystem.MoveFile(command);
    }

    public void CopyFile(CommandInformation.FileCopy command)
    {
        if (_currentFileSystem is null) throw new NotConnectedException();
        _currentFileSystem.CopyFile(command);
    }

    public void DeleteFile(CommandInformation.FileDelete command)
    {
        if (_currentFileSystem is null) throw new NotConnectedException();
        _currentFileSystem.DeleteFile(command);
    }

    public void RenameFile(CommandInformation.FileRename command)
    {
        if (_currentFileSystem is null) throw new NotConnectedException();
        _currentFileSystem.RenameFile(command);
    }
}