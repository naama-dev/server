using Microsoft.AspNetCore.Mvc;
using Models.Models;
using DAL.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDo _toDo;
        public ToDoController(IToDo toDo)
        {
            _toDo = toDo;
        }
        // GET: api/<ToDoController>
        [HttpGet]
        [Route("/todoget")]
        public async Task<ActionResult<List<ToDo>>> Get()
        {
            var res = await _toDo.getAllToDo();
            if (res.Count == 0)
                return BadRequest();
            return Ok(res);
        }

        // POST api/<ToDoController>
        [HttpPost]
        [Route("/todopost")]
        public async Task<ActionResult> PostToDo( [FromBody]ToDo t)
        {
            await _toDo.AddToDo(t);
            return Ok();
        }
       

        // PUT api/<ToDoController>/5
        [HttpPut]
        [Route("/todoput{id}")]
        public async Task<ActionResult> PutToDo(int id, [FromBody] ToDo t)
        {
            await _toDo.UpdateToDo(id, t);
            return Ok();
        }
        [HttpPut]
        [Route("/todoputiscomplete{id}")]
        public async Task<ActionResult> PutToDoIsComplete(int id)
        {
            await _toDo.IsCompleteToDo(id);
            return Ok();
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete]
        [Route("/tododelete{id}")]
        public async Task<ActionResult> DeleteToDo(int id)
        {
           await _toDo.DeleteToDo(id);
            return Ok();
        }
    }
}
