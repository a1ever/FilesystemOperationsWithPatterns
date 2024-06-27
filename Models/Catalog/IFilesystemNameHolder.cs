using FilesystemOperations.Services;

namespace FilesystemOperations.Models.Catalog;

public interface IFilesystemNameHolder
{
    void Accept(CatalogVisitor v);
}