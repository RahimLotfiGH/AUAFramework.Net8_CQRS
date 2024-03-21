using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using AUA.ProjectName.DomainEntities.Entities.Accounting.ClientAggregate;
using AUA.ProjectName.Models.DynamicAggregate.Accounting;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;
using Microsoft.IdentityModel.Tokens;

namespace AUA.ProjectName.Services.GeneralService.Login.Services
{
    public class GenerateJwtService : IGenerateJwtService
    {
        public string Generate(AccountLoginDto loginDto, Client client)
        {
            var secretKey = Encoding.UTF8.GetBytes(AccessTokenSetting.SecretKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encryptionKey = Encoding.UTF8.GetBytes(AccessTokenSetting.EncryptionKey);
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionKey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = GetClaims(loginDto, client.Id);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = AccessTokenSetting.Issuer,
                Audience = AccessTokenSetting.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(client.ClientTokenExpiration.NotBeforeMinutes),
                Expires = DateTime.Now.AddMinutes(client.ClientTokenExpiration.RefreshTokenExpirationMinutes),
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(claims),
                EncryptingCredentials = encryptingCredentials,
            };


            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(descriptor);

            var jwt = tokenHandler.WriteToken(securityToken);

            return jwt;
        }

        private static IEnumerable<Claim> GetClaims(AccountLoginDto loginDto, int clientId)
        {
            var list = new List<Claim>
            {
               new(ClaimTypes.NameIdentifier, loginDto.AppUserId.ToString()),
               new(ClaimTypeConsts.AccountId, loginDto.Id.ToString()),
               new(ClaimTypeConsts.ClientId,clientId.ToString()),
            };

            var claims = GetUserAccessCodes(loginDto);

            list.AddRange(claims);


            return list;
        }

        private static IEnumerable<Claim> GetUserAccessCodes(AccountLoginDto loginDto)
        {
            return loginDto.UserAccessCodes
                           .Select(claim => new Claim(ClaimTypes.Role, claim.GetId().ToString()));
        }
    }
}
