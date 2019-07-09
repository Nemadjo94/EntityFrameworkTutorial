using EntityFrameworkExplained.Constraints;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExplained.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        //GET: /<controller>/
        [Route("")]
        public IActionResult Index()
        {
            return Content("Index action method");
        }
        //[Route("Home/Index3")]
        //public IActionResult Index2()
        //{
        //    return Content("Index2 action method");
        //}

        [HttpGet("Index3")]
        public IActionResult Index2_Get()
        {
            return Content("Index2 get method");
        }
        [HttpPost("Index3")]
        public IActionResult Index2_Post()
        {
            return Content("Index2 post method");
        }
        [AcceptHeader("text/html")]
        [HttpGet("Index2")]
        public IActionResult Index2_HTML()
        {
            return Content("HTML response returns");
        }
        [AcceptHeader("application/json")]
        [HttpGet("Index2")]
        public IActionResult Index2_JSON()
        {
            return Content("Json response returns");
        }

        [Route("/Employee/SayHello/{id}")]
        public IActionResult SayHello(int id)
        {
            return Content("Say Hello action method " + id);
        }
        
    }
}
