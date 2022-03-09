using System;
using System.Collections.Generic;
using System.Text;

namespace Jan.IoC
{
    internal class ServiceMetadata
    {
        public Type ServiceType { get; set; }

        public Type ImplementationType { get; set; }

        public LifecycleType LifecycleType { get; set; }
    }
}
