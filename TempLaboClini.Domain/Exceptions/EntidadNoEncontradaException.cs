namespace TempLaboClini.Domain.Exceptions
{
    public class EntidadNoEncontradaException : Exception
    {
        public EntidadNoEncontradaException(string entidad, long id)
            : base($"La entidad '{entidad}' con ID '{id}' no fue encontrada.")
        {
        }
    }


}
