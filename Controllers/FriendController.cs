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
        if(ModelState.IsValid){
            FriendService.AddFriend(newFriend);
        }else{
            ViewBag.error = "Friend not added - Invalid Friend Details";
        }
        ViewBag.friends = FriendService.GetFriendList();
        return View();
    }

    public IActionResult New(){
        return View();
    }

    [HttpGet]
    public IActionResult Update(Guid id){
        ViewBag.friend = FriendService.FindFriend(id);
        return View();
    }

    [HttpPost]
    public IActionResult Update(Friend friend){
        if(ModelState.IsValid){
            FriendService.UpdateFriend(friend);
        }else{
            ViewBag.error = "Friend not updated - Invalid Friend Details";
        }
        ViewBag.friends = FriendService.GetFriendList();
        return View("Index");
    }

    public IActionResult Delete(Guid id){
        FriendService.RemoveFriend(id);
        ViewBag.friends = FriendService.GetFriendList();
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
