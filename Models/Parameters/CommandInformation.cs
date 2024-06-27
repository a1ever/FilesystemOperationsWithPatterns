namespace FilesystemOperations.Models.Parameters;

#pragma warning disable
public abstract record CommandInformation
{
    private CommandInformation() { }

    public sealed record Connect(string Address, ParameterWithValue Mode, IReadOnlyList<ParameterWithValue>? Parameters = null) : CommandInformation;
    public sealed record Disconnect() : CommandInformation;
    public sealed record TreeGoto(string Path, IReadOnlyList<ParameterWithValue>? Parameters) : CommandInformation;
    public sealed record TreeList(ParameterWithValue Depth, IReadOnlyList<ParameterWithValue>? Parameters = null) : CommandInformation;
    public sealed record FileShow(string Path, ParameterWithValue Mode, IReadOnlyList<ParameterWithValue>? Parameters = null) : CommandInformation;
    public sealed record FileMove(string Path, string Destination, IReadOnlyList<ParameterWithValue>? Parameters = null) : CommandInformation;
    public sealed record FileCopy(string Path, string Destination, IReadOnlyList<ParameterWithValue>? Parameters = null) : CommandInformation;
    public sealed record FileDelete(string Path, IReadOnlyList<ParameterWithValue>? Parameters = null) : CommandInformation;
    public sealed record FileRename(string Path, string Name, IReadOnlyList<ParameterWithValue>? Parameters = null) : CommandInformation;
}