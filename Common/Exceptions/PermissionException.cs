namespace Common.Exceptions
{
    public class PermissionException : IdentitySpaceException
    {
        public PermissionException()
            :base(ExceptionType.Permission)
        {
            HttpStatusCode = 401; 
            ClientMessage = "Sorry, You don't have a permission to do this action. "; 
        }

        public PermissionException(string action)
            : base(ExceptionType.Permission)
        {
            HttpStatusCode = 401; 
            this.ClientMessage = $"Sorry, You don't have a permission to {action}";
        }
    }
}
