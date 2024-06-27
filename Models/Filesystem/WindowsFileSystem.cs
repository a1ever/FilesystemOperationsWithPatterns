using FilesystemOperations.Models.Catalog;
using FilesystemOperations.Models.Parameters;
using FilesystemOperations.Services;

namespace FilesystemOperations.Models.Filesystem;

public class WindowsFileSystem : ILocalFileSystem
{
    private string _currentLocation = @"C:\";

    public WindowsFileSystem(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Connect(CommandInformation.Connect connect)
    {
        if (connect is null) throw new ArgumentNullException(nameof(connect));
        _currentLocation = connect.Address;
    }

    public void SystemGoTo(CommandInformation.TreeGoto command)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));
        string path = CheckFileExists(command.Path);

        _currentLocation = path;
    }

    public void WatchCurrentCatalog(CommandInformation.TreeList command)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));

        int depth;
        bool failure = int.TryParse(command.Depth.Value, out depth);
        if (failure)
        {
            depth = 1;
        }

        FolderHolder folder = CatalogInput(new DirectoryInfo(_currentLocation), 0,  depth);
        folder.Accept(new CatalogVisitor(new ConsoleOutput()));
    }

    public void ShowFile(CommandInformation.FileShow command)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));
        string path = CheckFileExists(command.Path);

        File.Exists(command.Path);

        if (command.Mode.Value == "console")
        {
            new ConsoleOutput().Write(File.ReadAllText(path));
        }
    }

    public void MoveFile(CommandInformation.FileMove command)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));
        string path = CheckFileExists(command.Path);
        string dir = CheckDirExists(command.Destination);

        File.Move(path, Path.Combine(dir, Path.GetFileName(command.Path)));
    }

    public void CopyFile(CommandInformation.FileCopy command)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));
        string path = CheckFileExists(command.Path);
        string dir = CheckDirExists(command.Destination);

        File.Copy(path, Path.Combine(dir, Path.GetFileName(command.Path)));
    }

    public void DeleteFile(CommandInformation.FileDelete command)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));
        string path = CheckFileExists(command.Path);

        File.Delete(path);
    }

    public void RenameFile(CommandInformation.FileRename command)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));
        string path = CheckFileExists(command.Path);
        string dest = Path.Combine(Path.Combine(Path.GetDirectoryName(path) ?? throw new InvalidOperationException(), Path.GetFileName(command.Name)));
        CheckFileAlreadyExists(dest);
        File.Move(path, dest);
    }

    private static void CheckFileAlreadyExists(string path)
    {
        if (File.Exists(path))
        {
            throw new InvalidOperationException();
        }
    }

    private string CheckFileExists(string path)
    {
        if (File.Exists(path))
        {
            return path;
        }

        string newPath = Path.Combine(_currentLocation, path);
        if (File.Exists(newPath))
        {
            return newPath;
        }

        throw new FileNotFoundException();
    }

    private string CheckDirExists(string path)
    {
        if (Directory.Exists(path))
        {
            return path;
        }

        string newPath = Path.Combine(_currentLocation, path);
        if (Directory.Exists(newPath))
        {
            return newPath;
        }

        throw new FileNotFoundException();
    }

    private FolderHolder CatalogInput(DirectoryInfo di, int depth, int maxDepth)
    {
        if (depth == maxDepth)
        {
            return new FolderHolder(di.Name, null, null);
        }

        return new FolderHolder(
            di.Name,
            di.GetFiles().Select(x => new FilenameHolder(x.Name)).ToList(),
            di.GetDirectories().Select(x => CatalogInput(x, depth + 1, maxDepth)).ToList());
    }
}