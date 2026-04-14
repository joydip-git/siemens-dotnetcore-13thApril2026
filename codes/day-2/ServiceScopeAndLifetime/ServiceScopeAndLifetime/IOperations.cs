namespace ServiceScopeAndLifetime
{
    public interface IOperations : IDisposable
    {
        int CreateAccount(string name, string panCardNo);
        double Credit(int accNo, double amount);
    }
}
