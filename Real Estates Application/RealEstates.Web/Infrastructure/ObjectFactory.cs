namespace RealEstates.Web.Infrastructure
{
    using Registries;
    using StructureMap;
    using System;
    using System.Threading;

    public static class ObjectFactory
    {
        private static readonly Lazy<Container> ContainerBuilder = new Lazy<Container>(
            DefaultContainer,
            LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return ContainerBuilder.Value; }
        }

        private static Container DefaultContainer()
        {
            return new Container(cfg =>
            {               
                cfg.AddRegistry(new MvcRegistry());
            });
        }
    }
}