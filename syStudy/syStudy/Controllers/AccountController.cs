using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using syStudy.DataContext;
using syStudy.Models;
using syStudy.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace syStudy.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // ID, 비밀번호 - 필수
            if (ModelState.IsValid)
            {
                using (var db = new BoardDbContext())
                {
                    var user = db.Users
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId) &&
                                             u.UserPassword.Equals(model.UserPassword));
                    if (user != null)
                    {
                        // 로그인 성공
                        // HttpContext.Session.SetInt32(key, value);
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);
                        return RedirectToAction("LoginSuccess", "Home");   
                    }
                }
                // 로그인 실패
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 회원 가입 전송
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BoardDbContext())
                {
                    db.Users.Add(model);    // 메모리에 올리기
                    db.SaveChanges();   // Commit
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
