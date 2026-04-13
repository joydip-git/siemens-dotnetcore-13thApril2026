using System.Net.Mail;

namespace DIAdvanced
{
    public class AdvanedMessenger : IMessenger
    {
        public string Greet(string name)
        {
            var client = new SmtpClient("localhost", 3000);
            client.Send($"joydip@gmail.com", "anish@gmail.com", "Hello", $"Welcome to .NET Core {name}");
            return "email sent";
        }
    }
}
