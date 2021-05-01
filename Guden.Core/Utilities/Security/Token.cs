using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Guden.Core.Utilities.Security
{
    public static class Token
    {
        /// <summary>
        /// UserId döndürür.
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public static int GetUserId(ClaimsPrincipal User)
        {
            return int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}
