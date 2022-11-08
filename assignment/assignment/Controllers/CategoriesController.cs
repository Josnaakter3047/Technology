
using Microsoft.AspNetCore.Mvc;
using assignment.Models;
using assignment.Repository;

namespace assignment.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ExpenseDbContext db;
        private readonly IRepo<Category> repo;
        public CategoriesController(ExpenseDbContext db, IRepo<Category> repo)
        {
            this.db = db;
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var category = repo.GetAll();
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            var cat = category.CategoryName;
            var duplicate = (from c in db.Categories where c.CategoryName == cat select c).ToList();
            if (duplicate.Count >= 1)
            {
                return PartialView("_duplicate");
            }
            else if (category!=null)
            {
                repo.Insert(category);
                repo.Save();
                return PartialView("_success");
            }

            else
            {
                return PartialView("_error");
            }
        }
        
        public IActionResult Edit(int id)
        {
            var category = repo.GetById(id);
            return View(category);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            var cat = category.CategoryName;
            var duplicate = (from c in db.Categories where c.CategoryName == cat select c).ToList();
            if (duplicate.Count >= 1)
            {
                return PartialView("_duplicate");
            }
            else if (category != null)
            {
                repo.UpdateData(category);
                repo.Save();
                return PartialView("_success");
            }
            else
            {
                return PartialView("_error");
            }

        }
        public IActionResult Delete(int id)
        {
            var category = repo.GetById(id);
            repo.Delete(category);
            repo.Save();
            return RedirectToAction("Index");
        }
    }
}
