using System;

namespace TempLaboClini.Domain.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message)
            : base(message)
        {
        }
    }
}
