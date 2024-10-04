using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Web.Areas.Admin.Users;

namespace Template.Web.Areas.Admin_Full.Users
{
    [Area("Admin_Full")]
    public partial class UsersController : Controller
    {
        // GET: Admin_Full/Users
        public virtual IActionResult Index(int page = 1, string searchTerm = null, string deviceTypeFilter = null,
                                   string deviceStatusFilter = null, string deviceWarrantyFilter = null)
        {
            var viewModel = GetIndexViewModel(page, searchTerm, deviceTypeFilter, deviceStatusFilter, deviceWarrantyFilter);
            return View(viewModel);
        }

        // GET: Admin_Full/Users/Details/5
        public virtual IActionResult DetailsUser(int id)
        {
            var user = GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Admin_Full/Users/Create
        public virtual IActionResult CreateUser()
        {
            return View();
        }

        [HttpGet]
        public virtual IActionResult Index(IndexViewModel model)
        {
            return View(model);
        }

        // POST: Admin_Full/Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult CreateUser(IndexViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                CreateUserInDb(userViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        // GET: Admin_Full/Users/Edit/5
        public virtual IActionResult EditUser(int id)
        {
            var user = GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Admin_Full/Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult EditUser(int id, IndexViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateUserInDb(id, userViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        // GET: Admin_Full/Users/Delete/5
        public virtual IActionResult DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Admin_Full/Users/Delete/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public virtual IActionResult DeleteConfirmed(int id)
        {
            DeleteUserFromDb(id);
            return RedirectToAction(nameof(Index));
        }

        // Utility methods (example placeholders)
        private IndexViewModel GetIndexViewModel(int page, string searchTerm, string deviceTypeFilter, string deviceStatusFilter, string deviceWarrantyFilter)
        {
            // Logica per ottenere i dati per la vista di indice
            return new IndexViewModel();
        }

        private IndexViewModel GetUserById(int id)
        {
            // Logica per ottenere un singolo utente per ID
            return new IndexViewModel();
        }

        private void CreateUserInDb(IndexViewModel userViewModel)
        {
            // Logica per creare l'utente
        }

        private void UpdateUserInDb(int id, IndexViewModel userViewModel)
        {
            // Logica per aggiornare l'utente
        }

        private void DeleteUserFromDb(int id)
        {
            // Logica per cancellare l'utente
        }
    }
}
