namespace ErrorLoggerDemo.Services
{
    public interface IErrorLogger
    {
        void LogError(Exception e);
    }
}