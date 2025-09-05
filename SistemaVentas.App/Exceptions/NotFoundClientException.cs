namespace SistemaVentas.App.Exceptions
{
    public class NotFoundClientException(string message):NotFoundException(message)
    {
    }
}
