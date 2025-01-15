using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Friendly.Filters;

public class ClearErrorMessage : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if(!filterContext.ModelState.IsValid){
            filterContext.ModelState.AddModelError("FriendId", "Not allowed");
        }
    }
    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        filterContext.ModelState.ClearValidationState("FriendId");
    }
}
