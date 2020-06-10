using HMS.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class HMSRolesManagerService :RoleManager<IdentityRole>
    {
        public HMSRolesManagerService(IRoleStore<IdentityRole, string> roleStore):base(roleStore)
        {
            
        }
        public static HMSRolesManagerService Create(IdentityFactoryOptions<HMSRolesManagerService>options, IOwinContext context)
        {
            return new HMSRolesManagerService(new RoleStore<IdentityRole>(context.Get<HMSContext>()));
        }
    }
}
