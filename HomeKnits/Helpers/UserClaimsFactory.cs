using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace HomeKnits.Helpers
{
    public class UserClaimsFactory : UserClaimsPrincipalFactory<IdentityUser>
    {
        public UserClaimsFactory(
            UserManager<IdentityUser> userManager,
            IOptions<IdentityOptions> options) : base(userManager, options)
        {}

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserId", user.Id));
            identity.AddClaim(new Claim("UserEmail", user.Email ?? ""));
            return identity;
        }
    }
}
