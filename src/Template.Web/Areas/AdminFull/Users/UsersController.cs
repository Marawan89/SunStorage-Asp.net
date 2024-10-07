using Microsoft.AspNetCore.Mvc;

namespace Template.Web.Areas.AdminFull.Users
{
    public partial class UsersController : Controller
    {
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}
