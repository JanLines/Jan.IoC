using System;
using System.Collections.Generic;
using System.Text;

namespace Jan.IoC
{
    internal class ServiceInstanceManager
    {
        private Dictionary<Type, object> _singletonInstances = new Dictionary<Type, object>();

        public TService GetInstance<TService>(ServiceMetadata serviceMetadata)
        {
            var serviceInstance = serviceMetadata.LifecycleType switch
            {
                LifecycleType.Transient => GetTransientInstance<TService>(serviceMetadata),
                LifecycleType.Singleton => GetSingletonInstance<TService>(serviceMetadata),
                _ => throw new NotImplementedException($"No implementation of GetInstance for LifecycleType: {serviceMetadata.LifecycleType}.")
            };

            return serviceInstance;
        }

        private TService GetTransientInstance<TService>(ServiceMetadata serviceMetadata)
            => (TService)Activator.CreateInstance(serviceMetadata.ImplementationType);

        private TService GetSingletonInstance<TService>(ServiceMetadata serviceMetadata)
        {
            if (!_singletonInstances.ContainsKey(serviceMetadata.ServiceType))
            {
                var serviceInstance = (TService)Activator.CreateInstance(serviceMetadata.ImplementationType);
                _singletonInstances.Add(serviceMetadata.ServiceType, serviceInstance);
            }

            return (TService)_singletonInstances[serviceMetadata.ServiceType];            
        }
    }
}
