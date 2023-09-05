using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public static List<User> AllUsersList = new (); //to create views model




    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }



    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }



    [HttpPost("users/create")] //if using route instead of asp- would be no leading slash here but in HTML it is needed for the route
    public IActionResult CreateUser(User newUser) //because class in model/form uses the same, can excpet User object
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine($"{newUser.Name} is located in {newUser.Location} and their favorite language is {newUser.FavoriteLanguage}");
            AllUsersList.Add(newUser); //if validations pass, add the newUser coming in
            return RedirectToAction("AllUsers");
        }
        return View("Index"); //can not redirect because we will lose those errors
    }


    [HttpGet("users")]
    public ViewResult AllUsers ()
    {
        return View(AllUsersList); //passing in the variable we created for the view model above
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
