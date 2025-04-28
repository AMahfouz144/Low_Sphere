using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Common.Common
{
    public class CurrentUser : ICurrentUser
    {
        private readonly Claim[] claims;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor?.HttpContext;
            if (httpContext is null)
            {
                throw new InvalidOperationException($"Could not get HttpContext information. This exception might be because you are using '{nameof(ICurrentUser)}' in a background service where there is no user information. Please, note that '{nameof(ICurrentUser)}' can only be used in HTTP request pipeline where a current user is set.");
            }
            var user = httpContext.User;
            if (user is null)
            {
                throw new InvalidOperationException($"Could not get current user information.");
            }
            claims = user.Claims?.ToArray() ?? Array.Empty<Claim>();
        }

        private List<string> GetClaimValues(string claimName) => claims.Where(a => a.Type == claimName).Select(a => a.Value).ToList();
        private string GetClaimValue(string claimName) => claims.FirstOrDefault(a => a.Type == claimName)?.Value;

        public string UserId => GetClaimValue("UserId");

        public Guid Id => string.IsNullOrWhiteSpace(UserId) ? Guid.Empty : Guid.Parse(UserId);

        public string Fullname => GetClaimValue("UserNname");

        public List<string> Roles => GetClaimValues(ClaimTypes.Role);

        //public UserType UserType => (UserType)Convert.ToInt32(GetClaimValue("UserType"));

        public Guid TokenId
        {
            get
            {
                Guid.TryParse(GetClaimValue("TokenId"), out Guid tokenId);
                return tokenId;
            }
        }
    }
}
