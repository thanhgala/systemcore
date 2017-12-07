using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SystemCore.Web.Extensions;

namespace SystemCore.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var email = User.GetSpecificClaimn("Email");
            return View();
        }
    }
}