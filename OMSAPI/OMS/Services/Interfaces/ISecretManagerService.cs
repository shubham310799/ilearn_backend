namespace OMS.Services.Interfaces
{
    public interface ISecretManagerService
    {
        string GetSecret(string key);
    }
}
