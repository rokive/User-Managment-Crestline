using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entity.Models;
using Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserInformationService _userInformationService;

        public HomeController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            UserInformation user = _userInformationService.Login(login);

            if(user==null)
            {
                ViewBag.Error = "User name or password invalid";
            }
            else if (!user.isConfirm)
            {
                ViewBag.Error = "Please Confirm your email address";
            }
            else
            {
                ViewBag.Success = "Login Successfully";
                return View("Index");
                
            }
            return View();
        }

        public IActionResult Registration()
        {
            return View();   
        }

        [HttpPost]
        public IActionResult Registration(UserInformation userInformation)
        {
            bool isUserNameExist = _userInformationService.GetUsertNameExist(userInformation.UserName);
            if (ModelState.IsValid&&!isUserNameExist)
            {
                _userInformationService.AddUserInformation(userInformation);
                TempData["Success"]= "Thank you for your registration. As soon as you will receive a confirmation mail" +
                    "in your email address. If you are unable to find it in your inbox then please check your spam folder.";
                return View("Login");
            }
            else if (isUserNameExist)
            {
                ViewBag.Error = "This user name already exist.";
            }
            else
            {
                ViewBag.Error = "something is worng";
            }
            return View();
        }
        
        public IActionResult EmailConfirmation(string activationCode)
        {
            bool isValid= _userInformationService.GetCheckEmailConfirmation(activationCode);
            if (isValid)
            {
                TempData["Success"] = "Successfully confirm your email address";
                return View("Login");
            }
            else
            {
                ViewBag.Error = "Invalid activation code";
                return View();
            }

        }

        public IActionResult PasswordRecovery()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PasswordRecovery(PasswordRecovery  passwordRecovery)
        {
            if (_userInformationService.GetPasswordRecovery(passwordRecovery))
            {
                
                TempData["Token"] = Guid.NewGuid().ToString("N");
                TempData["UserName"] = passwordRecovery.UserName;
                return View("NewPassword");
            }
            else
            {
                ViewBag.error= "Invalid user name or answer";
            }
            return View();
        }

        public IActionResult NewPassword()
        {
            
            if (TempData["Token"] != null)
            {
                return View();
            }
            else
            {
                ViewBag.Error = "Bad request";
                return View("Index");
            }
        }

        [HttpPost]
        public IActionResult NewPassword(NewPassword newPassword)
        {
            if (ModelState.IsValid)
            {
                _userInformationService.UpdatePasswor(newPassword.UserName, newPassword.Password);
                TempData["Success"] = "Password change successfully";
                return View("Login");
            }
            else
            {
                ViewBag.Error = "Bad request";
                return View("Index");
            }
           
          
        }

        public IActionResult UserNameRecovery()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserNameRecovery(string userName)
        {
            if (_userInformationService.GetUserNameRecovery(userName))
            {
                ViewBag.success = "This user name is valid email addresses";
            }
            else
            {
                ViewBag.error = "This user name is invalid email addresses";
            }
            return View();
        }

    }
}
