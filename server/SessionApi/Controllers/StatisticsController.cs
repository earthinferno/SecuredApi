using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SessionApi.Models;

namespace SessionApi.Controllers
{
    [Route("statistics")]
    [Authorize]
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            //var stubData = new SessionStats { UserSessions = new UserSessionAggregator { Logons = 42, StartDateTime = DateTime.Now.AddDays(-30), EndDateTime = DateTime.Now } };
            var stubData = new SessionStats { UserSessions = new UserSessionAggregator { Logons = 42 } };

            return new JsonResult(stubData);
        }
    }
}