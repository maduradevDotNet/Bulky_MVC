using BulkWeb.Data;
using BulkWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> obj = _db.Categories;
            return View(obj);
        }

        public IActionResult create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }   
        }


        public IActionResult Edit(int id)
        {
            if(id== null || id==0)
            {
                return NotFound();
            }
            Category obj = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category obj = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null) { 
                return NotFound();
            }
           
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            
        }



    }
}
