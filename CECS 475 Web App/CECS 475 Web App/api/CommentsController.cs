using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CECS_475_Web_App.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CECS_475_Web_App.api
{
    [Route("api/posts/{postKey}/[controller]")]
    public class CommentsController : Controller
{

        private readonly ForumDataContext _db;

        public CommentsController(ForumDataContext db)
        {
            _db = db;
        }
    // GET: api/<controller>
    [HttpGet]
    public IQueryable<Comment> Get(string postKey)
    {
        return _db.Comments.Where(x=> x.Post.key == postKey);
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<controller>
    [HttpPost]
    public Comment Post(string postKey, [FromBody]Comment comment)
    {
           var post = _db.Posts.FirstOrDefault(x => x.key == postKey);

            if (post == null)
                return null;

            comment.Post = post;
            comment.Posted = DateTime.Now;
            comment.Author = User.Identity.Name;

            _db.Comments.Add(comment);
            _db.SaveChanges();

            return comment;
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
}
