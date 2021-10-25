 using GraduationProject.Models.DAO;
using GraduationProject.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GraduationProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        FurnitureEntities furnitureEntities = new FurnitureEntities();
         public ActionResult Information()
        {
            ViewBag.Info = new AccountDao().listInformation(Session["IdCu"].ToString());
            return View();
        }
        public  ActionResult changePassWordView()
        {
            var emails = Session["Email"].ToString();
             ViewBag.PassWord = new AccountDao().PassWord(emails);
            return View();
        }
        public ActionResult changePassWord(string OldPassword, string NewPassword, string ConfirmPassword)
        {
            var emails = Session["Email"].ToString();

            var passWord = new AccountDao().PassWord(emails);
             
            if (OldPassword.Equals(passWord)) ViewBag.OldPassword = "";
            else ModelState.AddModelError("OldPassword", "Mật khẩu cũ không đúng");
            if (ConfirmPassword.Equals(NewPassword)) ViewBag.ConfirmPassword = "";
            else ModelState.AddModelError("ConfirmPassword", "Xác nhận lại mật khẩu không đúng");

            if (ViewBag.OldPassword == "" && ViewBag.ConfirmPassword == "")
            {
                ModelState.AddModelError("result", "Đổi mật khẩu thành công");
                Account account = new Account();
                var email = Session["Email"].ToString();

                var accounts = furnitureEntities.Accounts.Find(email);
                account.PassWord = NewPassword;
                furnitureEntities.Entry(accounts).State = EntityState.Modified;
                furnitureEntities.SaveChanges();

            }
            return View("changePassWordView");
        }
        public ActionResult editInfo(Customer customer, string Day, string Month, string Year)
        {
             var IdCuSession = Session["IdCu"].ToString();
             DateTime DayOfBirth = new DateTime( int.Parse(Year), int.Parse(Month), int.Parse(Day));
             customer.IdCu = IdCuSession;
            customer.DateOfBirth = DayOfBirth;
            new AccountDao().editInfo(customer);
            ViewBag.Info = new AccountDao().listInformation(Session["IdCu"].ToString());
            return View("Information");
        }
        public ActionResult Login()
        {
            Session.Clear();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            Session["Role"] = "null";
            Session["Email"] = "null";
             return View();
        }
        public ActionResult LoginPost(Account account, string returnURL = "")
        {

            var obj = furnitureEntities.Accounts.Where(a => a.Email.Equals(account.Email) && a.PassWord.Equals(account.PassWord) && a.Role == account.Role).FirstOrDefault();
            var obj1 = furnitureEntities.Customers.Where(a => a.Email.Equals(account.Email)).FirstOrDefault();
            if (obj != null)
            {
                Session["Role"] = obj.Role.ToString();
                Session["NameCu"] = obj1.NameCu.ToString();
                Session["IdCu"] = obj1.IdCu.ToString();
                Session["Email"] = obj1.Email.ToString();
                ConstantSession.Email = obj.Email;
                Session.Add(ConstantSession.Email, obj);
                FormsAuthentication.SetAuthCookie(account.Email, false);
                if (Url.IsLocalUrl(returnURL) && returnURL.Length > 1 && returnURL.StartsWith("/") && returnURL.StartsWith("//") && returnURL.StartsWith("/\\"))
                {
                    return Redirect(returnURL);
                }
                if (Session["Role"].Equals("1"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (Session["Role"].Equals("0"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                

            }


            ModelState.AddModelError("SessionLogin", "Tên đăng nhập hoặc mật khẩu không đúng");
            return View("Login");
        }

    }

     
}