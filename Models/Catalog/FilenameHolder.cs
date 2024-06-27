using FilesystemOperations.Services;

namespace FilesystemOperations.Models.Catalog;

public class FilenameHolder : IFilesystemNameHolder
{
    public FilenameHolder(string filename)
    {
        Filename = filename;
    }

    public string Filename { get; }
    public void Accept(CatalogVisitor v)
    {
        v?.OutputFile(this);
    }
}