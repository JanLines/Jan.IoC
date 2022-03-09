using System;
using System.Collections.Generic;

namespace Jan.IoC
{
    public class Container
    {
        private readonly Dictionary<Type, ServiceMetadata> _registeredServices = new Dictionary<Type, ServiceMetadata>();
        private readonly ServiceInstanceManager _serviceInstanceManager = new ServiceInstanceManager();

        /// <summary>
        /// Registers a service type and its implementation into the IoC container.
        /// </summary>
        /// <typeparam name="TService">Service Dependency</typeparam>
        /// <typeparam name="TImplementation">Implementation of the Service</typeparam>
        /// <param name="lifeCycleType">Lifetime of the object instance.</param>
        public void Register<TService, TImplementation>(LifecycleType lifeCycleType = LifecycleType.Transient)
            where TService : class
            where TImplementation : TService, new()
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
        
        /// <summary>
        /// Requests for an implementation instace of a given service dependency from the IoC container.
        /// </summary>
        /// <typeparam name="TService">Service Dependency</typeparam>
        /// <returns>Implementation Instance of the service</returns>
        public TService Resolve<TService>()
            where TService : class
        {
            var serviceType = typeof(TService);
            if (!_registeredServices.ContainsKey(serviceType))
            {
                throw new DependencyRegistrationDoesNotExistException($"Dependency registration of {serviceType} Service Type coes not exist.");
            }

            var serviceMetadata = _registeredServices[serviceType];
            var serviceInstance = _serviceInstanceManager.GetInstance<TService>(serviceMetadata);

            return serviceInstance;
        }       
    }
}
