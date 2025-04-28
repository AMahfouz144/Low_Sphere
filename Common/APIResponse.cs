namespace Common
{
    public class APIResponse<T>
    {
        public T Result { set; get; }
        public bool IsError { set; get; }
        public string ErrorMessage { set; get; }

        public APIResponse()
        {
            Result = default(T);
        }

        public APIResponse(T resultObject) : this()
        {
            Result = resultObject;
        }

        public static implicit operator APIResponse<T>(T result)
        {
            return new APIResponse<T>() { Result = result };
        }
    }

    public class APIResponse : APIResponse<object>
    {
        public static APIResponse Void
        {
            get
            {
                return new APIResponse();
            }
        }

        public APIResponse()
        {
            Result = null;
        }
    }
}
