using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhoto _photo;
        public PhotoController(IPhoto photo)
        {
            _photo = photo;
        }
        // GET: api/<PhotoController>
        [HttpGet]
        [Route("/photoget")]
        public async Task<ActionResult<List<Photo>>> Get()
        {
            var res = await _photo.getAllPhotos();
            if (res.Count == 0)
                return BadRequest();
            return Ok(res);
        }
       
        // GET api/<PhotoController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<PhotoController>
        [HttpPost]
        [Route("/photopost")]
        public async Task<ActionResult> PostPhoto([FromBody] Photo p)
        {
            await _photo.AddPhoto(p);
            return Ok();
        }

        // PUT api/<PhotoController>/5
        [HttpPut]
        [Route("/photoput{id}")]
        public async Task<ActionResult> PutPhoto(int id, [FromBody] Photo p)
        {
            await _photo.UpdatePhoto(id, p);
            return Ok();
        }


        // DELETE api/<PhotoController>/5
        [HttpDelete]
        [Route("/photodelete{id}")]
        public async Task<ActionResult> DeletePhoto(int id)
        {
            await _photo.DeletePhoto(id);
            return Ok();
        }
    }
}
