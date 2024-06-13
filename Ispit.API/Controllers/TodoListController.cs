using Ispit.API.Models.Binding;
using Ispit.API.Models.ViewModels;
using Ispit.API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
 
       private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
           _todoListService = todoListService;
        }

        [HttpGet("TodoList")]
        [ProducesResponseType(typeof(List<TodoListViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TodoListViewModel>>> GetAllTodo()
        {
            var TodoList = await _todoListService.GetAllTodoList();
            return Ok(TodoList);
        }
        [HttpPut]
        [ProducesResponseType(typeof(TodoListViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<TodoListViewModel>> Update(TodoListUpdateBinding model)
        {
            var result = await _todoListService.UpdatetodoList(model);

            return Ok(result);

        }


        [HttpPost("CreateTodo")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Add(TodoListBinding model)
        {


            var todo = await _todoListService.CreateTodotask(model);
            return Ok(todo);


        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _todoListService.DeleteTodo(id);
            return Ok(new { Poruka = $"Todo sa idom {id} je uspješno obrisan!" });
        }
    }
}
