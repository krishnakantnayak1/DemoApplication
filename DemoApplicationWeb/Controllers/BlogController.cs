using DemoApplicationWeb.Data;
using DemoApplicationWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplicationWeb.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDBContext _db;

        public BlogController(ApplicationDBContext db) {  _db = db; }
        public List<Blog> Index()
        {
            var blogList=_db.Blogs.ToList();
            Console.WriteLine(blogList);
            return blogList;
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Blog obj)
        {
            if(ModelState.IsValid) {
                _db.Blogs.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }
    }
}