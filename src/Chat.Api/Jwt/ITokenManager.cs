using System.Threading.Tasks;

namespace Chat.Api.Jwt
{
    public interface ITokenManager
    {
        Task<bool> IsCurrentActiveToken();
        Task<bool> IsActiveAsync(string token);
        Task DeactivateAsync(string token);
        Task DeactivateCurrentAsync();
    }
}
