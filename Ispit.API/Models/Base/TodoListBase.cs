namespace Ispit.API.Models.Base
{
    public abstract class TodoListBase
    {
      
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }


    }
}
