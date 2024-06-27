namespace FilesystemOperations.Exceptions;

public class NotConnectedException : ConnectException
{
    public NotConnectedException(string message)
        : base(message)
    {
    }

    public NotConnectedException()
    {
    }

    public NotConnectedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}