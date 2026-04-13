namespace NETFeatures_DI
{
    public class BankingOperations : IOperations
    {
        public int CreateAccount(string name, string panCardNo)
        {
            return new Random().Next(100, 10000);
        }

        public double Credit(int accNo, double amount)
        {
            return 1000 + amount;
        }
    }
}
