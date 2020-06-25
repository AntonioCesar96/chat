using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Primitives;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Api.Jwt
{
    public class TokenManager : ITokenManager
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenManager(IDistributedCache cache,
                IHttpContextAccessor httpContextAccessor
            )
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> IsCurrentActiveToken()
            => await IsActiveAsync(GetCurrentAsync());

        public async Task<bool> IsActiveAsync(string token)
            => await _cache.GetStringAsync(GetKey(token)) == null;

        public async Task DeactivateCurrentAsync()
            => await DeactivateAsync(GetCurrentAsync());

        public async Task DeactivateAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwttoken = tokenHandler.ReadToken(token);
            var expDate = jwttoken.ValidTo;
            var expiryMinutes = expDate.Subtract(DateTime.Now).TotalMinutes;

            await _cache.SetStringAsync(GetKey(token),
                " ", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromMinutes(expiryMinutes)
                });
        }

        private string GetCurrentAsync()
        {
            var authorizationHeader = _httpContextAccessor
                .HttpContext.Request.Headers["authorization"];

            return authorizationHeader == StringValues.Empty
                ? string.Empty
                : authorizationHeader.Single().Split(" ").Last();
        }

        private static string GetKey(string token)
            => $"tokens:{token}:deactivated";
    }
}
