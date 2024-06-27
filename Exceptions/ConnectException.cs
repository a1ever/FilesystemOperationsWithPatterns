namespace FilesystemOperations.Exceptions;

public class ConnectException : Exception
{
    public ConnectException(string message)
        : base(message)
    {
    }

    public ConnectException()
        : base("Exception with filesystem connection")
    {
    }

    public ConnectException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}