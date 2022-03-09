using NUnit.Framework;

namespace Jan.IoC.Tests
{
    class ContainerTests
    {
        [TestCase(LifecycleType.Transient)]
        [TestCase(LifecycleType.Singleton)]
        public void Can_Register_A_Dependency(LifecycleType lifecycle)
        {                        
            var container = new Container();
            Assert.DoesNotThrow
            (
                () => container.Register<IDummyService, DummyService>(lifecycle)
            );
        }

        [Test]
        public void Should_Throw_Error_If_Dependency_Is_Already_Registered()
        {
            var container = new Container();
            container.Register<IDummyService, DummyService>();

            Assert.Throws<DependencyAlreadyRegisteredException>
            (
                () => container.Register<IDummyService, AnotherDummyService>()
            );
        }
    }
}
