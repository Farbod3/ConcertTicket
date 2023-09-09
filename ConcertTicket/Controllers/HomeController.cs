using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebFramework.BaseController;

namespace ConcertTicket.Controllers;

public class HomeController : BaseController
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("سلام من به تو یار قدیمی !!!!!" +
                  "در اینجا یک بک اند کولیده را مشاده میکنید");
    }
    
    
    // [Route("index")]
    // public IActionResult Index()
    // {
    //     return View();
    // }
    // [Route("about")]  
    // public IActionResult About()
    // {
    //     return View();
    // }
    //
    // [Route("services")]
    // public IActionResult Services()
    // {
    //     return View();
    // }
    // [Route("contact")]
    // public IActionResult Contact()
    // {
    //     return View(); 
    // }
    //

  
        // [Route("")]
        // [Route("Home")]
        // [Route("Home/Index")]
        // [Route("Home/Index/{id?}")]
        //  IActionResult Index(int? id)
        // {
        //     return ControllerContext.MyDisplayRouteInfo(id);
        // }
        //
        // [Route("Home/About")]
        // [Route("Home/About/{id?}")]
        // IActionResult About(int? id)
        // {
        //     return ControllerContext.MyDisplayRouteInfo(id);
        // }
    
}


