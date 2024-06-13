using AutoMapper;
using Ispit.API.Data;
using Ispit.API.Models.Binding;
using Ispit.API.Models.Dbo;
using Ispit.API.Models.ViewModels;
using Ispit.API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ispit.API.Service.Implementation
{
    public class TodoListService : ITodoListService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TodoListService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// All Todo List
        /// </summary>
        /// <returns></returns>
        public async Task<List<TodoListViewModel>> GetAllTodoList()
        {
            var dbo = await _context.TodoLists.ToListAsync();
            return _mapper.Map<List<TodoListViewModel>>(dbo);
        }
        /// <summary>
        /// Create new task on todo list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<TodoListViewModel> CreateTodotask(TodoListBinding model)
        {
            var todo = _mapper.Map<TodoList>(model);
            await _context.TodoLists.AddAsync(todo);
            await _context.SaveChangesAsync();
            return _mapper.Map<TodoListViewModel>(todo);
        }

        public async Task<bool> DeleteTodo(int Id)
        {
            var dbo = _context.TodoLists.Find(Id);
            _context.TodoLists.Remove(dbo);
            await _context.SaveChangesAsync();

            return true;

        }
        /// <summary>
        /// Update one of todo list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<TodoListViewModel> UpdatetodoList(TodoListUpdateBinding model)
        {
            var dbo = await _context.TodoLists.FindAsync(model.Id);
            _mapper.Map(model, dbo);
            await _context.SaveChangesAsync();
            return _mapper.Map<TodoListViewModel>(model);
        }
    }
}
