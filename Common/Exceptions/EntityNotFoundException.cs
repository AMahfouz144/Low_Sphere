namespace Common.Exceptions
{
    public class EntityNotFoundException : IdentitySpaceException
    {
        public string EntityName { set; get; }
        public string EntityId { set; get; }

        public EntityNotFoundException()
            : base(ExceptionType.EntityNotFound)
        {
            HttpStatusCode = 406; 
        }
    }

    public class EntityNotFoundException<T> : EntityNotFoundException
    {
        public EntityNotFoundException(string entityId,  string message)
            :base()
        {
            this.ClientMessage = message;
            this.EntityId = entityId;
            this.EntityName = nameof(T); 
        }

        public EntityNotFoundException(string entityId)
            :base ()
        {
            this.ClientMessage = $"object with id {entityId} is not found !";
            this.EntityId = entityId;
            this.EntityName = nameof(T);
        }
    }
}