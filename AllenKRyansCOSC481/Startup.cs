﻿using AllenKRyansCOSC481.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AllenKRyansCOSC481.Startup))]
namespace AllenKRyansCOSC481
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        public void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup create Admin role and default admin user    
            if (!roleManager.RoleExists("Admin"))
            {
                //create Admin role   
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);

                //admin credetials
                var user = new ApplicationUser
                {
                    UserName = "akronlineordering@gmail.com",
                    Email = "akronlineordering@gmail.com"
                };

                string userPWD = "akr_password";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating customer role    
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole
                {
                    Name = "Customer"
                };
                roleManager.Create(role);
            }
        }
    }
}
