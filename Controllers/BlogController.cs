using crudappMvc.Data;
using crudappMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace crudappMvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult GetAllBlog()
        {
            var blogs = _context.Blogs.ToList();
            return View(blogs);

            //foreach (var item in blogs)
            //{
            //    ViewBag.Id = item.Id;
            //}
        }

        [HttpGet]
        public IActionResult CreateBlog()
        {
            return View();
        }



        public IActionResult CreateBlog(Blog userData)
        {

            if (ModelState.IsValid)
            {
                _context.Blogs.Add(userData);
                _context.SaveChanges();

                return RedirectToAction("GetAllBlog");
            }

            return View();
        }


        public IActionResult Details(int id)
        {
            var blog = _context.Blogs.Find(id);
          
            return View(blog);
        }


        public IActionResult Delete(int id)
        {
            var DeleteBlogPost = _context.Blogs.Find(id);


            if(DeleteBlogPost != null)
            {

                _context.Blogs.Remove(DeleteBlogPost);
                _context.SaveChanges();
                return RedirectToAction("GetAllBlog");

            }
            return View("GetAllBlog");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var BlogDetail = _context.Blogs.Find(id);
       
            return View(BlogDetail);

        }

        [HttpPost]
        public IActionResult Edit(Blog userData)
        {

            if (ModelState.IsValid)
            {
                _context.Blogs.Update(userData);
                _context.SaveChanges();

                return RedirectToAction("GetAllBlog");
            }

            return View();
        }

    }
}
