using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoWebApp.Base;
using ToDoWebApp.Models;

namespace ToDoWebApp.Controllers
{
    public class HomeController : Controller
    {
        private TodoDbContext dbContext;
        public HomeController(TodoDbContext Context)
        {
            dbContext = Context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetToDoItems()
        {
            return await dbContext.ToDoSet.ToListAsync();
        }

        [HttpPost]
        public IActionResult PostToDoItem(TodoModel model)
        {
            dbContext.ToDoSet.Add(model);
            dbContext.SaveChanges();
            return Ok(model);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var Model = dbContext.ToDoSet.Find(id);
            if (Model == null)
            {
               return NotFound();
            }
            
            dbContext.ToDoSet.Remove(Model);
            dbContext.SaveChanges();

            return Ok();
        
        }


            

       
    }
}
