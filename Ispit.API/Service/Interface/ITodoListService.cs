using Ispit.API.Models.Binding;
using Ispit.API.Models.ViewModels;

namespace Ispit.API.Service.Interface
{
    public interface ITodoListService
    {
        Task<TodoListViewModel> CreateTodotask(TodoListBinding model);
        Task<bool> DeleteTodo(int Id);
        Task<List<TodoListViewModel>> GetAllTodoList();
        Task<TodoListViewModel> UpdatetodoList(TodoListUpdateBinding model);
    }
}