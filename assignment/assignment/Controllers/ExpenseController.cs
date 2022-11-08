
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using assignment.Models;
using assignment.Repository;
using Microsoft.AspNetCore.Authorization;

namespace assignment.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseDbContext db;
        private readonly IRepo<Expenditures> repo;
        private readonly IRepo<Category> repoCat;

        public ExpenseController(ExpenseDbContext db, IRepo<Expenditures> repo, IRepo<Category> repoCat)
        {
            this.db = db;
            this.repo = repo;
            this.repoCat = repoCat;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var expenses = (from e in db.Expenditures
                            join c in db.Categories on e.CategoryId equals c.Id
                            select new ExpenseView
                            {
                                Id = e.Id,
                                CategoryName = c.CategoryName,
                                DateOfExpense = e.DateOfExpense,
                                CategoryId = e.CategoryId,
                                TotalAmount = e.TotalAmount
                            }).ToList();
            return View(expenses);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewBag.categoryList = repoCat.GetAll();
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expenditures expense)
        {
            ViewBag.categoryList = repoCat.GetAll();
            
            if (expense.DateOfExpense > DateTime.Today.Date)
            {
                return PartialView("_dateerror");
            }
            else if (expense.CategoryId==0)
            {
                return PartialView("_categoryerror");
            }
            else if (expense != null)
            {
                repo.Insert(expense);
                repo.Save();
                return PartialView("_success");
            }
            else
            {
                return PartialView("_error");
            }

        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            ViewBag.categoryList = repoCat.GetAll();
            var expenditures = db.Expenditures.FirstOrDefault(x => x.Id == id);
            return View(expenditures);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Expenditures expense)
        {
            ViewBag.categoryList = repoCat.GetAll();
            if (expense.DateOfExpense > DateTime.Today.Date)
            {
                return PartialView("_dateerror");
            }
            else if (expense.CategoryId == 0)
            {
                return PartialView("_categoryerror");
            }
            else if (expense != null)
            {
                repo.UpdateData(expense);
                repo.Save();
                return PartialView("_success");
            }
            else
            {
                return PartialView("_error");
            }

        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var expenditures = repo.GetById(id);
            repo.Delete(expenditures);
            repo.Save();
            return RedirectToAction("Index");
        }
    }
}
