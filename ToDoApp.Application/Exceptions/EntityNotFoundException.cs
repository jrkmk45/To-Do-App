namespace ToDoApp.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Guid Id { get; set; }
        public EntityNotFoundException(Guid id) : base($"No entity with id: {id}") 
        {
            Id = id;
        }
    }
}
