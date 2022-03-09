using NUnit.Framework;

namespace Jan.IoC.Tests
{
    class Container_Resolve_Tests
    {
        [TestCase(LifecycleType.Transient)]
        [TestCase(LifecycleType.Singleton)]
        public void Can_Resolve_A_Dependency_That_Is_Registered(LifecycleType lifecycleType)
        {
            var container = new Container();
            container.Register<IDummyService, DummyService>(lifecycleType);

            var resolvedService = container.Resolve<IDummyService>();

            Assert.IsInstanceOf<DummyService>(resolvedService);
        }

        [Test]
        public void Should_Throw_Error_If_Dependency_Is_Not_Registered()
        {
            var container = new Container();
            
            // intentionally not registering any services, for the purpose of this test case

            Assert.Throws<DependencyRegistrationDoesNotExistException>
            (
              () => container.Resolve<IDummyService>()
            );                        
        }
    }
}
