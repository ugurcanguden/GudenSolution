using Microsoft.AspNetCore.Mvc;
using Guden.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Guden.Business.Abstract.Core;
using System.Linq;
using System.Security.Claims;

namespace Guden.Api.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private ICore_MenuService _menuService;

        public AuthController(IAuthService authService, ICore_MenuService core_MenuService)
        {
            _authService = authService;
            _menuService = core_MenuService;
        }
        /// <summary>
        /// Kullanıcı login işlemini yapar..
        /// </summary>
        /// <param name="userForLoginDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            { 
                return Ok(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
               
                return Ok(result);
            }

            return Ok(result);

        }
        /// <summary>
        /// Kullanıcı kaydında kullanılır.
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <returns></returns>
      
        [HttpPost("Register")]
        public ActionResult Register( UserForRegisterDto userForRegisterDto)
        {
           //Kullanıcı var mı ?
            var userExists = _authService.UserExists(userForRegisterDto.Email,null);
            if (!userExists.Success)
            {
                return Ok(userExists);
            }
            //kullanıcı eklenir.
            var registerResult = _authService.Register(userForRegisterDto);
          
            if (registerResult.Success)
            {
                return Ok(registerResult);
            }

            return Ok(registerResult);
        }
        /// <summary>
        /// Kullanıcı kaydında kullanılır.
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <returns></returns>
    
        [HttpPost("UpdateUser")]
        public ActionResult UpdateUser(UserForRegisterDto userForRegisterDto)
        {
            //Kullanıcı var mı ?
            var userExists = _authService.UserExists(userForRegisterDto.Email,userForRegisterDto.Id);
            if (!userExists.Success)
            {
                return Ok(userExists);
            }
            //kullanıcı eklenir.
            var registerResult = _authService.UpdateUser(userForRegisterDto);

            if (registerResult.Success)
            {
                return Ok(registerResult);
            }

            return Ok(registerResult);
        }

        [HttpGet("getMenulistbyUseId")]
        [Authorize]
        public IActionResult GetCore_MenuListByUserId()
        {
            int userId = Guden.Core.Utilities.Security.Token.GetUserId(User);

            var result = _menuService.GetMenusByUser(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("getOperationClaimSelectList")]
       // [Authorize]
        public IActionResult GetCore_OperationClaimSelectList()
        {
            var result = _authService.GetOperationClaimSelectList();
            return Ok(result);
        }

    }
}
