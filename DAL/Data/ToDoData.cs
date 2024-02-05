using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Models.Models;
namespace DAL.Data
{
    public class ToDoData : IToDo
    {
        private readonly DataProjectContext _context;

        public ToDoData(DataProjectContext context)
        {
            _context = context;
        }
        public async Task<List<ToDo>> getAllToDo()
        {

            List<ToDo> todos = await _context.ToDo.ToListAsync();
            return todos;
        }
        public async Task<bool> AddToDo(ToDo todo)
        {
            
            await _context.ToDo.AddAsync(todo);
            try
            {

            var isOk = _context.SaveChanges() >= 0;
            }catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteToDo(int id)
        {
            var idTodo = _context.ToDo.FirstOrDefault(x => x.Id == id);
            _context.ToDo.Remove(idTodo);
            var isOk = _context.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> UpdateToDo(int id, ToDo todo)
        {
            var idTodo = _context.ToDo.FirstOrDefault(x => x.Id == id);
            if (idTodo == null)
            {
                return false;
            }
            idTodo.Name = todo.Name;
            idTodo.CreateDate = todo.CreateDate;
            idTodo.IsComplete = todo.IsComplete;
            try
            {
                var isOk = _context.SaveChanges() > 0;
            }
          catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> IsCompleteToDo(int id)
        {
            var idTodo = _context.ToDo.FirstOrDefault(x => x.Id == id);
            if (idTodo == null)
                return false;
            idTodo.IsComplete = !(idTodo.IsComplete);
            try
            {
                var isOk = _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
