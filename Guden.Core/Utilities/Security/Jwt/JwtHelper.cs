using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Guden.Core.Extensions;
using Guden.Core.Utilities.Security.Encyption;
using Microsoft.IdentityModel.Tokens;

namespace Guden.Core.Utilities.Security.Jwt
{
    public class JwtHelper:ITokenHelper
    {
        #region Definitions
        public IConfiguration Configuration { get; }
        private Guden.Core.Utilities.Security.Jwt.TokenOptions _tokenOptions;
        private DateTime _accessTokenExpirationn;
        #endregion

        /// <summary>
        /// Kurucu metod set işlemleri...
        /// </summary>
        /// <param name="configuration"></param>
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<Guden.Core.Utilities.Security.Jwt.TokenOptions>();
            _accessTokenExpirationn = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        /// <summary>
        /// Access Token oluşturulur...
        /// </summary>
        /// <param name="user"></param>
        /// <param name="operationClaims"></param>
        /// <returns></returns>
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
                        {
                            Token = token,
                            Expiration = _accessTokenExpirationn
            };
        }

        /// <summary>
        /// Security Token oluşturulur..
        /// </summary>
        /// <param name="tokenOptions"></param>
        /// <param name="user"></param>
        /// <param name="signingCredentials"></param>
        /// <param name="operationClaims"></param>
        /// <returns></returns>
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpirationn,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        /// <summary>
        /// Set claims metodu
        /// </summary>
        /// <param name="user"></param>
        /// <param name="operationClaims"></param>
        /// <returns></returns>
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email.ToString());
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c=>c.Name).ToArray());
            return claims;
        }
    }
}
