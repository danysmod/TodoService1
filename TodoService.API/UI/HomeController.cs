using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.UI
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Index()
        {
            var nameIdentifier = this.HttpContext.User.Claims
                                                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            abasdf
            return new string[] { nameIdentifier?.Value, "value1", "value2" };
        }
    }
}
