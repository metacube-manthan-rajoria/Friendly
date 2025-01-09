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
    [Route("/Friend")]
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

    [Route("/Friend/Add")]
    public IActionResult New(){
        return View(new Friend{FriendName=null, Place=null});
    }

    [HttpGet]
    public IActionResult Update(Guid id){
        ViewBag.friend = FriendService.FindFriend(id);
        return View(ViewBag.friend);
    }

    [HttpPost]
    public IActionResult Update(IFormCollection friend){
        try{
            if(ModelState.IsValid && !friend["FriendName"].Equals("")){
                try{
                    FriendService.UpdateFriend(new Friend{
                        FriendId = Guid.Parse(friend["FriendId"].ToString()),
                        FriendName = friend["FriendName"],
                        Place = friend["Place"]
                    });
                }
                catch (NullReferenceException){
                    ViewBag.error = "Friend not updated - Invalid Id";
                }
            }
            else{
                ViewBag.error = "Friend not updated - Invalid Friend Details";
            }
            ViewBag.friends = FriendService.GetFriendList();
            return View("Index");
        }
        catch{
            return StatusCode(500, "We ran into an error");
        }
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
