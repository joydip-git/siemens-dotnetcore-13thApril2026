using Microsoft.Extensions.Options;
using HostingDemo.Models;
using Microsoft.Extensions.Logging;
using System.Text;

namespace HostingDemo.Repository
{
    public class TextFileRepository : IFileRepository, IDisposable
    {
        private readonly string? filePath;
        private StreamReader? reader;

        public TextFileRepository(IOptions<FileSettingOptions> fileSettingOptions, ILogger<TextFileRepository> logger)
        {
            FileSettingOptions options = fileSettingOptions.Value;
            this.filePath = options.FilePath;
            logger.LogInformation(filePath);
        }

        public void Dispose()
        {
            //suppressing the finalizer if any
            GC.SuppressFinalize(this);
            reader?.Close();
            reader = null;
            Console.WriteLine("disposed...");
        }

        public string ReadData()
        {
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                //using var reader = new StreamReader(filePath);
                reader = new StreamReader(filePath);
                StringBuilder builder = new();
                string? data = null;
                if (!reader.EndOfStream)
                {
                    while (!string.IsNullOrEmpty(data = reader.ReadLine()))
                    {
                        builder.AppendLine(data);
                    }
                }
                return builder.ToString();
            }
            else
                throw new FileNotFoundException($"file not found at {filePath}");
        }
    }
}
