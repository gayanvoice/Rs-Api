using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rs_Api.Models;

namespace RsApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }

        [HttpGet("Status")]
        public IActionResult Status()
        {
            using (RsdbContext rsdbContext = new RsdbContext())
            {
                if (rsdbContext.Database.CanConnect())
                {
                    return Ok(true);
                }
                else
                {
                    return NoContent();
                }
            }
        }
    }
}