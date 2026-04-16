using Microsoft.Extensions.Options;
using OptionsPatternDemo.Models;

namespace OptionsPatternDemo.Repository
{
    public class TextFileRepository : IFileRepository
    {
        private readonly string? filePath;

        public TextFileRepository(IOptions<FileSettingOptions> fileSettingOptions)
        {
            FileSettingOptions options = fileSettingOptions.Value;
            this.filePath = options.FilePath;
        }

        public string ReadData()
        {
            return "file data";
        }
    }
}
