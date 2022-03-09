using System;
using System.Collections.Generic;
using System.Text;

namespace Jan.IoC
{
    public class DependencyAlreadyRegisteredException : Exception
    {
        public DependencyAlreadyRegisteredException(string message) : base(message)
        {
        }
    }
}
