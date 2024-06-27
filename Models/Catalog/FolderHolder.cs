using FilesystemOperations.Services;

namespace FilesystemOperations.Models.Catalog;

public class FolderHolder : IFilesystemNameHolder
{
    public FolderHolder(string name, IReadOnlyList<FilenameHolder>? file = null, IReadOnlyList<FolderHolder>? folders = null)
    {
        Name = name;
        File = file;
        Folders = folders;
    }

    public string Name { get; }
    public IReadOnlyList<FilenameHolder>? File { get; }
    public IReadOnlyList<FolderHolder>? Folders { get; }
    public void Accept(CatalogVisitor v)
    {
        v?.OutputFolder(this);
    }
}