using CabukHemenSimdiIzle.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Resend;
using CabukHemenSimdiIzle.MVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace CabukHemenSimdiIzle.MVC.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IToastNotification _toastNotification;
    //private readonly IResend _resend;
    private readonly IWebHostEnvironment _environment;

    public AuthController(UserManager<User> userManager, IToastNotification toastNotification, SignInManager<User> signInManager, IWebHostEnvironment environment)
    {
        _userManager = userManager;
        _toastNotification = toastNotification;
        _signInManager = signInManager;
        _environment = environment;
    }


    [HttpGet]
    public IActionResult Index()
    {

        return View();
    }


    [HttpGet]
    public IActionResult Register()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction(nameof(Login), "Auth");
        }

        var registerViewModel = new AuthRegisterVM();


        return View(registerViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync(AuthRegisterVM registerViewModel)
    {
        if (!ModelState.IsValid)
            return View(registerViewModel);

        var userId = Guid.NewGuid();

        var user = new User()
        {
            Id = userId,
            Email = registerViewModel.Email,
            FirstName = registerViewModel.FirstName,
            SurName = registerViewModel.SurName,
            Gender = registerViewModel.Gender,
            BirthDate = registerViewModel.BirthDate.Value.ToUniversalTime(),
            UserName = registerViewModel.UserName,
            CreatedOn = DateTimeOffset.UtcNow,
            CreatedByUserId = userId.ToString()
        };

        var identityResult = await _userManager.CreateAsync(user, registerViewModel.Password);

        if (!identityResult.Succeeded)
        {
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return View(registerViewModel);
        }

        _toastNotification.AddSuccessToastMessage("You've successfully registered to the application.");

        // Building the button's URL
        /*var token = await _userManager.GenerateEmailConfirmationTokenAsync(user); // token, UserId

         token = HttpUtility.UrlEncode(token);

         var buttonLink = $"https://localhost:7206/Auth/VerifyEmail?email={user.Email}&token={token}";

         //
         var wwwRootPath = _environment.WebRootPath;

         var fullPathToHtml = Path.Combine(wwwRootPath, "email-templates", "verify-email.html");

         var htmlText = await System.IO.File.ReadAllTextAsync(fullPathToHtml);

         var title = "Seri Film İzle - E-Posta Doğrulama";

         // Title
         htmlText = htmlText.Replace("{{Title}}", title);

         // Description
         htmlText = htmlText.Replace("{{Description}}",
             "Film Sitemize hoş geldiniz. E-Posta adresinizi doğrulamak için lütfen aşağıdaki \"Onayla\" butonuna tıklayınız.");

         htmlText = htmlText.Replace("{{ButtonLink}}", buttonLink);

         htmlText = htmlText.Replace("{{ButtonText}}", "Onayla");

         var message = new EmailMessage();
         message.From = "ahmetbalaman073@gmail.com";
         message.To.Add(user.Email);
         message.Subject = title;
         message.HtmlBody = htmlText;

         await _resend.EmailSendAsync(message);*/

        return RedirectToAction(nameof(Login));
    }


    [HttpGet] // localhost:7206/Auth/VerifyEmail?email=alpertunga@gmail.com&token=gkomaskdlqwenmjasksdaasdadasd
    public async Task<IActionResult> VerifyEmailAsync(string email, string token)
    {

        var user = await _userManager.FindByEmailAsync(email);

        var identityResult = await _userManager.ConfirmEmailAsync(user, token);

        if (!identityResult.Succeeded)
        {
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            _toastNotification.AddErrorToastMessage("We unfortunately couldn't verify your email.");

            return View();
        }


        _toastNotification.AddSuccessToastMessage("You've successfully verified your email address.");

        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity.IsAuthenticated)
        {
            TempData["ToastMessage"] = "SucessFully Logged!"; 
            return RedirectToAction("Index", "Home");
        }

        var loginViewModel = new AuthLoginVM();
        _toastNotification.AddSuccessToastMessage("You have sucesfully login it");
        return View(loginViewModel);
    }


    [HttpPost]
    public async Task<IActionResult> LoginAsync(AuthLoginVM loginViewModel)
    {
        if (!ModelState.IsValid)
            return View(loginViewModel);

        var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

        if (user is null)
        {
            _toastNotification.AddErrorToastMessage("Your email or password is incorrect.");

            return View(loginViewModel);
        }

        var loginResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, false);

        if (!loginResult.Succeeded)
        {
            TempData["ToastMessage"] = "SucessFully Logged!";
            _toastNotification.AddErrorToastMessage("Your email or password is incorrect.");

            return View(loginViewModel);
        }

        _toastNotification.AddSuccessToastMessage($"Welcome {user.UserName}!");

        return RedirectToAction("Index", controllerName: "Home");
    }
    public async Task<IActionResult> Logout()
    {

        await _signInManager.SignOutAsync();

        TempData["ToastMessage"] = "GoodBye :(";
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);


        return RedirectToAction("Index", "Home");
    }

}