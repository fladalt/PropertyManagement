using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using PropertyManagement.Application.Interfaces;

namespace PropertyManagement.Application.Services
{
    public class SMSNotifyer : ISMSNotifyer
    {
        private readonly SecretClient _secretClient;

        public SMSNotifyer(IConfiguration configuration)
        {
            var keyVaultUrl = configuration["KeyVaultUrl"];

            _secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
        }
        public async Task Notify(string message)
        {
            KeyVaultSecret secret = await _secretClient.GetSecretAsync("SMSNotifyerApiKey");
            // And there it is
        }
    }
}
