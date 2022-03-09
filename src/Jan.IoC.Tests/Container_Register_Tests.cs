using NUnit.Framework;

namespace Jan.IoC.Tests
{
    class Container_Register_Tests
    {
        [TestCase(LifecycleType.Transient)]
        [TestCase(LifecycleType.Singleton)]
        public void Can_Register_A_Dependency(LifecycleType lifecycleType)
        {                        
            var container = new Container();
            Assert.DoesNotThrow
            (
                () => container.Register<IDummyService, DummyService>(lifecycleType)
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
