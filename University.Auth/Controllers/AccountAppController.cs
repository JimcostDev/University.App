using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using University.Auth.Models;
using University.BL.DTOs;

namespace University.Auth.Controllers
{
    [RoutePrefix("api/AccountApp")]
    public class AccountAppController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountAppController()
        {
        }

        public AccountAppController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? Request.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // POST: /Account/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IHttpActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new ResponseDTO { Code = 400, Message = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) });
                }

                // No cuenta los errores de inicio de sesión para el bloqueo de la cuenta
                // Para permitir que los errores de contraseña desencadenen el bloqueo de la cuenta, cambie a shouldLockout: true
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        var user = await UserManager.FindByEmailAsync(model.Email);
                        return Ok(new ResponseDTO { Code = 200, Data = user });
                    //case SignInStatus.LockedOut:
                    //case SignInStatus.Failure:
                    default:
                        return Ok(new ResponseDTO { Code = 401, Message = "Invalid login attempt." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = 500, Message = ex.Message });
            }

        }
        // POST: /Account/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return Ok(new ResponseDTO { Code = 200});
                    }
                    else
                        return Ok(new ResponseDTO { Code = 500, Message = string.Join(", ", result.Errors.Select(x => x)) });

                }

                return Ok(new ResponseDTO { Code = 400, Message = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = 500, Message = ex.Message });
            }
        }
    }
}
