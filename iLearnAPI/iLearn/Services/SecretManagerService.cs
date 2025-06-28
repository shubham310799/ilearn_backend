using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using OMS.Services.Interfaces;

namespace OMS.Services
{
    public class SecretManagerService : ISecretManagerService
    {
        private readonly SecretClient _client;

        public SecretManagerService(string secretUrl)
        {
            _client = new SecretClient(new Uri(secretUrl), new DefaultAzureCredential());
        }
        public string GetSecret(string key)
        {
            KeyVaultSecret secret = _client.GetSecret(key);
            return secret.Value;
        }
    }
}
