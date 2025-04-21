using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALABAT.CORE.Entities.Identity;

namespace TALABAT.REPOSITORY.Identity
{
     public class AppIdentitySeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> _userManager)
        {
            // تحقق إذا كانت قاعدة البيانات تحتوي على أي مستخدمين
            if (_userManager.Users.Count() == 0)
            {
                //// إنشاء الدور "Admin" إذا لم يكن موجودًا
                //var roleExist = await roleManager.RoleExistsAsync("Admin");
                //if (!roleExist)
                //{
                //    var roleResult = await roleManager.CreateAsync(new IdentityRole("Admin"));
                //    if (!roleResult.Succeeded)
                //    {
                //        throw new Exception("Error creating Admin role");
                //    }
                //}

                // إنشاء مستخدم جديد
                var user = new AppUser()
                {
                    DisplayName = "Ahmed Nasr",
                    Email = "ahmed.Kassem@linkdev.com",
                    UserName = "ahmed.Kassem",
                    PhoneNumber = "01122334455"
                };

                // إنشاء المستخدم بكلمة مرور
                var userResult = await _userManager.CreateAsync(user, "Password@123");

                //if (userResult.Succeeded)
                //{
                //    // إضافة المستخدم إلى الدور "Admin"
                //    await userManager.AddToRoleAsync(user, "Admin");
                //}
                //else
                //{
                //    throw new Exception("Error creating user");
            }
            }
        }
}
