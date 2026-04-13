namespace DIService
{
    public class DIContainer
    {
        private static DIContainer container = new();
        private static ICollection<Registry> registryEntries = new HashSet<Registry>();

        private DIContainer() { }
        public static DIContainer Create() => container;

        public DIContainer Register<TInterface, TClass>()
        {
            Type svcType = typeof(TInterface);
            Type implType = typeof(TClass);
            var entry = new Registry { ImplementationType = implType, ServiceType = svcType };
            registryEntries.Add(entry);
            return this;
        }
        public void Register<TClass>()
        {
            Type implType = typeof(TClass);
            var entry = new Registry { ImplementationType = implType };
            registryEntries.Add(entry);
        }

        public TInterface GetService<TInterface>()
        {
            Type? implType = null;

            if (registryEntries.Count > 0)
            {
                foreach (Registry item in registryEntries)
                {
                    if (item.ServiceType == typeof(TInterface))
                    {
                        implType = item.ImplementationType;
                        break;
                    }
                }
            }

            if (implType != null)
            {
                object? obj = Activator.CreateInstance(implType);
                if (obj != null)
                    return (TInterface)obj;
                else
                    throw new Exception("could not create instance");
            }
            else
                throw new Exception("no such service is registered");
        }

        class Registry
        {
            public Type? ServiceType { get; set; }
            public required Type ImplementationType { get; set; }
        }
    }
}
