using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guden.Core.Utilities.Security.Encyption
{
    public class SecurityKeyHelper
    {
        /// <summary>
        /// Security Key oluşturur..
        /// </summary>
        /// <param name="securityKey"></param>
        /// <returns></returns>
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
