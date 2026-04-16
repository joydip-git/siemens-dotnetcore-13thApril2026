using System.Text;

namespace ErrorLoggerDemo.Services
{
    //dependency inject IOptions<FileSetting> here and assign FileSetting.Path property value to the path data member
    public class ErrorLogger(string path) : IErrorLogger
    {
        private readonly string? path = path;
        //public ErrorLogger(string path)
        //{
        //    path = path;
        //}
        public void LogError(Exception e)
        {
            try
            {
                if (path !=null && File.Exists(path))
                {
                    using StreamWriter writer = new(path, true);
                    StringBuilder builder = new();
                    builder
                        .AppendLine("Logged at: " + DateTime.Now)
                        .AppendLine("Details")
                        .AppendLine($"Message: {e.Message}")
                        .AppendLine($"Source: {e.Source}")
                        .AppendLine($"Method: {e.TargetSite}")
                        .AppendLine($"Complete details: {e.StackTrace}")
                        .AppendLine($"Inner exception: {e.InnerException}");

                    writer.WriteLine(builder.ToString());
                    writer.Flush();
                }
                else
                    throw new FileNotFoundException($"file not present at {path}");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
