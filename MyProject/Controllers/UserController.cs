using DAL.Data;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }
        // GET: api/<UserController>
        [HttpGet]
        [Route("/userget")]
        public async Task<ActionResult<List<User>>> Get()
        {
            var res = await _user.getAllUsers();
            if (res.Count == 0)
                return BadRequest();
            return Ok(res);
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("/userpost")]
        public async Task<ActionResult> PostUser([FromBody] User u)
        {
            await _user.AddUser(u);
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut]
        [Route("/userput{id}")]
        public async Task<ActionResult> PutUser(int id, [FromBody] User u)
        {
            await _user.UpdateUser(id,u);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete]
        [Route("/userdelete{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _user.DeleteUser(id);
            return Ok();
        }
    }
}
