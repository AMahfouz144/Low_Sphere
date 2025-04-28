namespace Common.Common
{
    public class ServerResponse<T>
    {
        public T Result { set; get; }

        public ServerResponse()
        {
            Result = default(T);
        }

        public ServerResponse(T resultObject) : this()
        {
            Result = resultObject;
        }

        public static implicit operator ServerResponse<T>(T result)
        {
            return new ServerResponse<T>() { Result = result };
        }
    }

    public class ServerResponse : ServerResponse<object>
    {
        public static ServerResponse Void
        {
            get
            {
                return new ServerResponse();
            }
        }

        public ServerResponse()
        {

        }
    }
}