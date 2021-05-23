using System;

namespace WorkshopASPMVC.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base (message) { }
    }
}
