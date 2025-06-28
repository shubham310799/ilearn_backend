namespace OMS.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GenerateJwt(string username);
    }
}
