using Chat.Domain.Contatos.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chat.Api.Jwt
{
    public class TokenService
    {
        private readonly JwtSettings _settings;

        public TokenService(JwtSettings settings)
        {
            _settings = settings;
        }

        public string GenerateToken(ContatoDto contato)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, contato.Email.ToString()),
                }),
                Expires = _settings.AccessTokenExpiration,
                SigningCredentials = _settings.SigningCredentials
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
