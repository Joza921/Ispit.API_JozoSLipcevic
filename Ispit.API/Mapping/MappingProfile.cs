using AutoMapper;
using Ispit.API.Models.Binding;
using Ispit.API.Models.Dbo;
using Ispit.API.Models.ViewModels;

namespace Ispit.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoList, TodoListViewModel>();
            CreateMap<TodoListBinding, TodoList>();
            CreateMap<TodoListUpdateBinding, TodoListViewModel>();
            CreateMap<TodoListUpdateBinding, TodoList>().ReverseMap();
        }
    }
}
