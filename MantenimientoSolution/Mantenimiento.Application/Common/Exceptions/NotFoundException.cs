namespace Mantenimiento.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key)
        : base($"La entidad \"{name}\" ({key}) no fue encontrada.")
    {
    }
}
