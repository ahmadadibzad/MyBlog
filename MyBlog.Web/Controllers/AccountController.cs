using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.Application.Common.Utilities;
using MyBlog.Domain.Entities;
using MyBlog.Infrastructure.Repositories.Common;
using MyBlog.Web.ViewModels;

namespace MyBlog.Web.Controllers;

public class AccountController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<BlogUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<BlogUser> _signInManager;

    public AccountController(
        IUnitOfWork unitOfWork,
        UserManager<BlogUser> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<BlogUser> signInManager
        )
    {
        _roleManager = roleManager;
        _signInManager = signInManager;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public IActionResult Login(string returnUrl = null)
    {
        returnUrl ??= Url.Content("~");

        var loginVm = new LoginVM
        {
            RedirectUrl = returnUrl,
        };

        return View(loginVm);
    }

    public IActionResult Register()
    {
        if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
        {
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
        }

        var registerVM = new RegisterVM
        {
            RoleList = _roleManager.Roles.Select(r => new SelectListItem 
            { 
                Text = r.Name, 
                Value = r.Name 
            })
        };

        return View(registerVM);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if (ModelState.IsValid)
        {
            BlogUser user = new()
            {
                Name = registerVM.Name,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
                NormalizedEmail = registerVM.Email.ToUpper(),
                EmailConfirmed = true,
                UserName = registerVM.Email,
                CreatedAt = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(registerVM.Role))
                {
                    await _userManager.AddToRoleAsync(user, registerVM.Role);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, SD.Role_Customer);
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
                if (string.IsNullOrEmpty(registerVM.RedirectUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return LocalRedirect(registerVM.RedirectUrl);
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        registerVM.RoleList = _roleManager.Roles.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Name
        });

        return View(registerVM);
    }
}
