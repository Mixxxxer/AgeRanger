using System;

namespace AgeRanger.Domain.Exceptions
{
    public class PersonException : Exception
    {
        public PersonException(string message) : base(message)
        {
        }

        public PersonException(string message, Exception innerException) : 
            base(message, innerException)
        {
        }
    }
}
