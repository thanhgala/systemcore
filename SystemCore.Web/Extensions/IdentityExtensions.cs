using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SystemCore.Web.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetSpecificClaimn(this ClaimsPrincipal claimsPrincipal, string claimnType)
        {
            var claimn = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimnType);
            return (claimn != null) ? claimn.Value : string.Empty;
        }
    }
}
