using System;
using System.Collections.Generic;

namespace Jan.IoC
{
    public class Container
    {
        private readonly Dictionary<Type, ServiceMetadata> _registeredServices = new Dictionary<Type, ServiceMetadata>();

        public void Register<TService, TImplementation>(LifecycleType lifeCycleType = LifecycleType.Transient)
            where TService : class
            where TImplementation : TService
        {
            var serviceType = typeof(TService);

            if (_registeredServices.ContainsKey(serviceType))
            {
                throw new DependencyAlreadyRegisteredException($"Dependency registration of {serviceType} Service Type already exists.");
            }

            var serviceMetadata = new ServiceMetadata
            {
                ServiceType = serviceType,
                ImplementationType = typeof(TImplementation),
                LifecycleType = lifeCycleType,
            };

            _registeredServices.Add(serviceType, serviceMetadata);
        }

        public TService Resolve<TService>()
            where TService : class
        {
            throw new NotImplementedException();
        }
    }
}
