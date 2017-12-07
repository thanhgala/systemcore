using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SystemCore.Application.Interfaces;
using SystemCore.Application.ViewModels.System;
using SystemCore.Utilities.Constants;
using SystemCore.Web.Extensions;

namespace SystemCore.Web.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        IFunctionService _functionService;
        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaimn("Roles");
            List<FunctionViewModel> functions;
            if (roles.Split(";").Contains(CommonConstants.AdminRole))
            {
                functions = await _functionService.GetAll();
            }
            else
            {
                functions = new List<FunctionViewModel>();
            }
            return View(functions);
        }
    }
}
