using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SessionApi.Controllers
{
    [Route("profile")]
    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}