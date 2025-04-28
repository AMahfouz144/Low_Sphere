namespace Common.Logger
{
    public interface IVLogger
    {
        bool Error(string message, string clientMessage, string stacktrace, string description, int type);
        bool Error(string message, string source);
        bool Info(string message, string source);
        bool Warning(string message, string source);

        void Critical(string message, string rid, string description = null);

        void Watch(string message);
        void Watch(string message, string rid);

        void Audit(string action, string userId, string description, string rid);
        void Audit(string action, string userId, string description);
    }
}