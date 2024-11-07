namespace Helper
{
    public class HelperClass
    {
        public string GetCredential()
        {
            var configurationBuilder = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory()) 
         .AddJsonFile("appsettings.json", optional: false); 

            var configuration = configurationBuilder.Build();

            var password = configuration["AzurePassword"];

            return password;
        }


    }
}
