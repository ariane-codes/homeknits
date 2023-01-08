using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace HomeKnits.Helpers
{
    public class UserClaimsFactory : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
    {
        public UserClaimsFactory(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
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
