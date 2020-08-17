using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SessionApi.Models;
using SessionService;
using System.Linq;

namespace SessionApi.Controllers
{
    [Route("profile")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserSession _userSession;
        public ProfileController(IUserSession userSession)
        {
            _userSession = userSession;
        }

        public IActionResult Index()
        {
            var sessionProfile = _userSession.GetSessionProfile();
            var profile = new Profile
            {
                Name = sessionProfile.Name,
                Organization = sessionProfile.Organization,
                Email = sessionProfile.Email
            };

            return new JsonResult(profile);
        }
    }
}