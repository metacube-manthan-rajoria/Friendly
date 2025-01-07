using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Friendly.Models;
using Friendly.Services;

namespace Friendly.Controllers;

public class FriendController : Controller
{
    private readonly ILogger<FriendController> _logger;

    public FriendController(ILogger<FriendController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.friends = FriendService.GetFriendList();
        return View();
    }

    [HttpPost]
    public IActionResult Index(Friend newFriend){
        newFriend.FriendId = Guid.NewGuid();
        FriendService.AddFriend(newFriend);
        ViewBag.friends = FriendService.GetFriendList();
        return View();
    }

    public IActionResult New(){
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
