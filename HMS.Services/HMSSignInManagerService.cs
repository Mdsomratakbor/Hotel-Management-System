using HMS.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class HMSSignInManagerService : SignInManager<HMSUser, string>
    {
        public HMSSignInManagerService(HMSUserManagerService userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(HMSUser user)
        {
            return user.GenerateUserIdentityAsync((HMSUserManagerService)UserManager);
        }

        public static HMSSignInManagerService Create(IdentityFactoryOptions<HMSSignInManagerService> options, IOwinContext context)
        {
            return new HMSSignInManagerService(context.GetUserManager<HMSUserManagerService>(), context.Authentication);
        }
    }
}
