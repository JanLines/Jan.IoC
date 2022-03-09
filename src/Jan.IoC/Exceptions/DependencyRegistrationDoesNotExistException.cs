using System;
using System.Collections.Generic;
using System.Text;

namespace Jan.IoC
{
    public class DependencyRegistrationDoesNotExistException : Exception
    {
        public DependencyRegistrationDoesNotExistException(string message) : base(message)
        {
        }
    }
}
