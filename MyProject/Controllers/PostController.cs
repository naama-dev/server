using DAL.Data;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPost _post;
        public PostController(IPost post)
        {
            _post = post;
        }
        // GET: api/<PostController>
        [HttpGet]
        [Route("/postget")]
        public async Task<ActionResult<List<Post>>> Get()
        {
            var res = await _post.getAllPosts();
            if (res.Count == 0)
                return BadRequest();
            return Ok(res);
        }
      
        // POST api/<PostController>
        [HttpPost]
        [Route("/post-post")]
       
        public async Task<ActionResult> PostPost([FromBody] Post p)
        {
            await _post.AddPost(p);
            return Ok();
        }

        // PUT api/<PostController>/5
        [HttpPut]
        [Route("/post-put{id}")]
        public async Task<ActionResult> PutPost(int id, [FromBody] Post p)
        {
            await _post.UpdatePost(id, p);
            return Ok();
        }
        [HttpPut]
        [Route("/post-put-Like{id}")]
        public async Task<ActionResult> PutLike(int id)
        {
            await _post.IsLikePost(id);
            return Ok();
        }
        // DELETE api/<PostController>/5
        [HttpDelete]
        [Route("/post-delete{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _post.DeletePost(id);
            return Ok();
        }
    }
}