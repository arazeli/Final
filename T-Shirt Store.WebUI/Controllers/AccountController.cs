using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.Extensions;
using T_Shirt_Store.WebUI.Models.Entities.Membership;
using T_Shirt_Store.WebUI.Models.FormModels;

namespace T_Shirt_Store.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<T_ShirtUser> signInManager;
        private readonly UserManager<T_ShirtUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(SignInManager<T_ShirtUser> signInManager, UserManager<T_ShirtUser> userManager, IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }


        public IActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("/logout.html")]
        public async Task<IActionResult> LogOut()
        {

            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "home");
        }

        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new T_ShirtUser();
                user.UserName = model.Email;
                user.Email = model.Email;
                user.Name = model.Name;
                user.Surname = model.Surname;



                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);



                    string path = $"{Request.Scheme}://{Request.Host}/registration-confirm.html?email={user.Email}&token={token}";

                    var emailResponse = configuration.SendEmail(user.Email, "T_Shirt_Store Registration", $"Zehmet Olmasa <a href={path}>link</a> vasitesile qeydiyyati tamamlayasiniz ");

                    if (emailResponse)
                    {

                        ViewBag.Message = "Tebrikler qeydiyyat tamamlandi";
                    }
                    else
                    {

                        ViewBag.Message = "E-maile gondererken sehv ashkar olundu , yeniden cehd edin";
                    }


                    return RedirectToAction(nameof(SignIn));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }



            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginFormModel user)
        {
            if (ModelState.IsValid)
            {
                T_ShirtUser foundeduser = null;

                if (user.UserName.IsEmail())
                {
                    foundeduser = await userManager.FindByEmailAsync(user.UserName);
                }

                else
                {
                    foundeduser = await userManager.FindByNameAsync(user.UserName);
                }

                if (foundeduser == null)
                {
                    ViewBag.Message = "Istifadechi adiniz ve ya shifreniz yalnishdir";

                    goto end;
                }

                var singInResult = await signInManager.PasswordSignInAsync(foundeduser, user.Password, true, true);

                if (!singInResult.Succeeded)
                {
                    ViewBag.Message = "Xaish olunur yeniden yoxlayin";
                }

                var callbackUrl = Request.Query["ReturnUrl"];

                if (!string.IsNullOrWhiteSpace(callbackUrl))
                {
                    return Redirect(callbackUrl);
                }

                return RedirectToAction("Index", "Home");
            }

        end:
            return View(user);
        }

        [AllowAnonymous]
        public async Task<IActionResult> RegisterConfirm(string email, string token)
        {
            var foundedUser = await userManager.FindByEmailAsync(email);


            if (foundedUser == null)
            {
                ViewBag.Message = "Xetali Token";
                goto end;

            }

            token = token.Replace(" ", "+");

            var result = await userManager.ConfirmEmailAsync(foundedUser, token);

            if (!result.Succeeded)
            {
                ViewBag.Message = "Xeta!";
                goto end;
            }

            ViewBag.Message = "Hesabniz Tesdiglendi";

        end:
            return RedirectToAction(nameof(SignIn));
        }

        [Route("/accessdenied.html")]
        [AllowAnonymous]

        public IActionResult AccesDeny()
        {
            return View();
        }

       
    }
}
