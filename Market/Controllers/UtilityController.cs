using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Market.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Market.Controllers
{
   
    public class UtilityController : Controller
    {
        UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UtilityController(UserManager<User> User,RoleManager<IdentityRole> role)
        {
            userManager= User;
            roleManager = role;
        }
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Index()
        {
            var listOfUsers=userManager.Users.ToList();
            var lisOfRoles=roleManager.Roles.ToList();
            var userRoles =await userManager.GetRolesAsync(listOfUsers[0]);
            ViewBag.Users = new SelectList(listOfUsers,"Id","UserName");
            return View();
            
        }
        public async Task<IActionResult> ShowRoles(string id)
        {
            var user=await userManager.FindByIdAsync(id);
            var userRoles = await userManager.GetRolesAsync(user);
            var allRoles = roleManager.Roles.Select(a => a.Name).ToList();
            var userRolesNotIn = allRoles.Except(userRoles);
            ViewBag.userRoles = new SelectList(userRoles);
            ViewBag.userNotInRoles=new SelectList(userRolesNotIn);
            ViewBag.userId = id;
            return View();
        }
        public async Task<IActionResult> ChangeRoles(string id, string[] rolesToRemove, string[] rolesToAdd)
        {
            var user = await userManager.FindByIdAsync(id);
          //  await userManager.RemoveFromRolesAsync(user,rolesToRemove);
            await userManager.AddToRolesAsync(user,rolesToAdd);
           
           return RedirectToAction("Index");
        }
        
        public IActionResult Details()
        {
            return View();
        }
    }
}
