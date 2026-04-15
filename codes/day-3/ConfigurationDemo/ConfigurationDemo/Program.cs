using Microsoft.Extensions.Configuration;

namespace ConfigurationDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string?> inMemoryCollection = CreateInMemoryCollection();

            IConfigurationRoot configurationProvider = CreateConfigurationProvider(inMemoryCollection);
            
            Console.WriteLine("from in-memory collection\n");
            ReadFromInMemoryCollection(configurationProvider);

            Console.WriteLine("\nfrom json file\n");
            ReadFromJsonFile(configurationProvider);

            Console.WriteLine("\ndata through model binding\n");
            BindJsonFileSectionToModel(configurationProvider);
        }

        private static Dictionary<string, string?> CreateInMemoryCollection()
        {
            Dictionary<string, string?> inMemoryCollection = new();
            inMemoryCollection.Add("key1", "value1");
            inMemoryCollection.Add("constr", "server=.\\sqlexpress; database=siemensdb;integrated security=true; trust server certificate=true");
            return inMemoryCollection;
        }

        private static void BindJsonFileSectionToModel(IConfigurationRoot configurationProvider)
        {
            SiemensDbSetting? setting = configurationProvider
                            .GetRequiredSection("SiemensDbSetting")
                            .Get<SiemensDbSetting>();
            Console.WriteLine($"{setting?.Database}, {setting?.Server}, {setting?.Authentication?.IntegratedSecurity}, {setting?.Authentication?.TrustServerCertficate}");

            //Action<BinderOptions> optionsAction = (BinderOptions options) => 
            //{
            //    options.BindNonPublicProperties = true;
            //    options.ErrorOnUnknownConfiguration = true;                
            //};
            //configurationService.Get<SiemensDbSetting>(optionsAction);
        }

        private static void ReadFromJsonFile(IConfigurationRoot configurationProvider)
        {
            Console.WriteLine(configurationProvider["key2"]);

            IConfigurationSection keySection = configurationProvider.GetRequiredSection("key2");
            Console.WriteLine(keySection.Value);

            Console.WriteLine(configurationProvider.GetRequiredSection("SiemensDbSetting:Server").Value);
            Console.WriteLine(configurationProvider.GetRequiredSection("SiemensDbSetting:Authentication:IntegratedSecurity").Value);
        }

        private static void ReadFromInMemoryCollection(IConfigurationRoot configurationProvider)
        {           
            Console.WriteLine(configurationProvider["key1"]);
            Console.WriteLine(configurationProvider["constr"]);
        }

        private static IConfigurationRoot CreateConfigurationProvider(Dictionary<string, string?> inMemoryCollection)
        {
            ConfigurationBuilder builder = new();
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddInMemoryCollection(inMemoryCollection)
                .AddJsonFile("appsettings.json", false, true);

            IConfigurationRoot configurationProvider = builder.Build();
            return configurationProvider;
        }
    }
}
