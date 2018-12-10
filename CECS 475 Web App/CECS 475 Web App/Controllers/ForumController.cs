using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CECS_475_Web_App.Models;

namespace CECS_475_Web_App.Controllers
{
    [Route("forum")]
    public class ForumController : Controller
    {

        private readonly ForumDataContext _db;

        public ForumController(ForumDataContext db)
        {
            _db = db;
        }
        [Route("")]
        public IActionResult Index(int page = 0)
        {
            var pageSize = 4;
            var totalPosts = _db.Posts.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;
            var posts = _db.Posts.OrderByDescending(x => x.Posted).Skip(pageSize * page).Take(pageSize).ToArray();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(posts);

            return View(posts);
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = _db.Posts.FirstOrDefault(x => x.key == key);

            return View(post);
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Route("create")]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();

            post.User = User.Identity.Name;
            post.Posted = DateTime.Now;

            _db.Posts.Add(post);
            _db.SaveChanges();
            return RedirectToAction("Post", "Forum", new
            {
                year = post.Posted.Year,
                month = post.Posted.Month,
                key = post.key
            });
        }


    }
}