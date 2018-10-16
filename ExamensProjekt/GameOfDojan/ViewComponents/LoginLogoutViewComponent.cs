using Microsoft.AspNetCore.Mvc;

namespace GameOfDojan.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
