using System;

namespace Jan.IoC
{
    public class Container
    {
        public void Register<TService, TImplementation>(LifecycleType lifeCycleType = LifecycleType.Transient)
            where TService : class
            where TImplementation : TService
        {
            throw new NotImplementedException();
        }

        public TService Resolve<TService>()
            where TService : class
        {
            throw new NotImplementedException();
        }
    }
}
