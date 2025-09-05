namespace SistemaVentas.App.Exceptions
{
    public sealed class ConcurrencyException(string message, Exception innerException) : Exception(message, innerException)
    {
    }
}
