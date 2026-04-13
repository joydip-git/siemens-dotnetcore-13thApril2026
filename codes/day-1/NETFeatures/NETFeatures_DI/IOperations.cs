namespace NETFeatures_DI
{
    public interface IOperations
    {
        int CreateAccount(string name, string panCardNo);
        double Credit(int accNo, double amount);
    }
}
