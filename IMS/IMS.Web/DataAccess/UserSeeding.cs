using IMS.Web.DataAccess.Entities.Account;
using Microsoft.AspNetCore.Identity;

namespace IMS.Web.DataAccess
{
    public static class UserSeeding
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Admin", "Manager", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames) 
            {
                var roleExist= await roleManager.RoleExistsAsync(roleName);
                if(!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //CreateSuper User
            var superUser = new ApplicationUser
            {
                UserName = "super@email.com",
                Email= "super@email.com"
            };

            string userPassword = "Admin@12345";
            var user = await userManager.FindByEmailAsync(superUser.Email);

            if (user == null) 
            {
                var addSuperUser = await userManager.CreateAsync(superUser, userPassword);
                if (addSuperUser.Succeeded) 
                {
                    await userManager.AddToRoleAsync(superUser, "Admin");
                }
            }
        }
    }
}
