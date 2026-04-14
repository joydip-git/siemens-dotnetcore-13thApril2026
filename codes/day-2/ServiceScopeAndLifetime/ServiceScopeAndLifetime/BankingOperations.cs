namespace ServiceScopeAndLifetime
{
    public class BankingOperations : IOperations
    {
        //~BankingOperations() { }
        public BankingOperations()
        {
            Console.WriteLine("BO created...");
        }
        public int CreateAccount(string name, string panCardNo)
        {
            return new Random().Next(100, 10000);
        }

        public double Credit(int accNo, double amount)
        {
            return 1000 + amount;
        }

        public void Dispose()
        {
            //dsconnect from db
            //detatch file connection
            Console.WriteLine("BO disposed");
        }
    }
}
