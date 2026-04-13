namespace DIAdvanced
{
    public class SimpleMessenger : IMessenger
    {
        public string Greet(string name)
        {
            return $"Welcome {name}";
        }
    }
}
