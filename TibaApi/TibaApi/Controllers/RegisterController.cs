using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TibaApi.Model;

namespace TibaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IUsersCache _usersCache;
        private readonly IUserRepository _userRepository;

        public RegisterController(IUsersCache usersCache, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _usersCache = usersCache;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody]User register)
        {
            IActionResult response = Unauthorized();

            var user = _userRepository.FetchById(register.UserName);
            if (user != null)
                return response;

            register.UserRole = "User";
            _usersCache.InsertUser(register);
            _userRepository.Insert(register);
            response = Ok(new
            {
                userDetails = register,
            });

            return response;
        }
    }
}