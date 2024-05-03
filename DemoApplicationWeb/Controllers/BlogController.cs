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
        public Blog Get(int id)
        {
            return _db.Blogs.Find(id);
        }
        [HttpPost]
        public Blog Edit(Blog blog)
        {
            Blog x = _db.Blogs.Find(blog.id);
            if(x != null) {
                x.Content = blog.Content;
                _db.SaveChanges();
            }
            return x;
        }

        public void Delete(int id)
        {
            Blog b=_db.Blogs.Find(id);
            if(b != null) { 
            _db.Blogs.Remove(b);
            _db.SaveChanges();
            }
        }
    }
}