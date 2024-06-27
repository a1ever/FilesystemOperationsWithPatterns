using FilesystemOperations.Models.Catalog;

namespace FilesystemOperations.Services;

public class CatalogVisitor
{
    private char _fileSymbol;
    private char _tabSymbol;
    private char _folderSymbol;
    private int _currentDepth = 1;
    private IOutput _output;

    public CatalogVisitor(IOutput output, char folderSymbol = '%', char tabSymbol = '-', char fileSymbol = '*')
    {
        _output = output;
        _folderSymbol = folderSymbol;
        _tabSymbol = tabSymbol;
        _fileSymbol = fileSymbol;
    }

    public void OutputFolder(FolderHolder currentFolderHolder)
    {
        if (currentFolderHolder is null) return;

        _output.Write($"{TabGenerator()} {_folderSymbol} {currentFolderHolder.Name}");

        if (currentFolderHolder.File is not null)
        {
            foreach (FilenameHolder filenameHolder in currentFolderHolder.File)
            {
                filenameHolder.Accept(this);
            }
        }

        if (currentFolderHolder.Folders is null) return;
        foreach (FolderHolder folderHolder in currentFolderHolder.Folders)
        {
            _currentDepth += 1;
            folderHolder.Accept(this);
            _currentDepth -= 1;
        }
    }

    public void OutputFile(FilenameHolder filenameHolder)
    {
        _output.Write($"{TabGenerator()} {_fileSymbol} {filenameHolder?.Filename}");
    }

    private string TabGenerator()
    {
        string ans = string.Empty;
        for (int i = 0; i < _currentDepth; i++)
        {
            ans += _tabSymbol;
        }

        return ans;
    }
}