using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var stubData = new SessionStats { UserSessions = new UserSessionAggregator { Logons = 42, StartDateTime = new DateTime().AddDays(-30), EndDateTime = new DateTime() } };

            return new JsonResult(stubData);
        }
    }
}