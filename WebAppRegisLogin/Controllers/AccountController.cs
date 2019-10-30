using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRegisLogin.DBModel;
using WebAppRegisLogin.Models;

namespace WebAppRegisLogin.Controllers
{
    public class AccountController : Controller
    {
        UserDBEntities objuserDBEntities = new UserDBEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            UserModel objUserModel = new UserModel();
            return View(objUserModel);
        }

        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {
                User objUser = new DBModel.User();
                objUser.UserID = objUserModel.UserID;
                objUser.UserName = objUserModel.UserName;
                objUser.UserEmail = objUserModel.UserEmail;
                objUser.UserImage = objUserModel.UserImage;
                objUser.UserPassword = objUserModel.UserPassword;
                objuserDBEntities.Users.Add(objUser);
                objuserDBEntities.SaveChanges();
                // new add
                objUserModel = new UserModel();
                objUserModel.SuccessMessage = "User is sucessfully added";
                return View("Register");
            }
            return View();
        }

        public ActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();
            return View(objLoginModel);
        }

        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if(ModelState.IsValid)
            {
                if(objuserDBEntities.Users.Where(m => m.UserEmail == objLoginModel.Email && m.UserPassword ==
                objLoginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Invalid Email and Password");
                    return View();
                }
                else
                {
                    Session["Email"] = objLoginModel.Email;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return View("Login");
        }


    }
}