namespace DelegatePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Calculation calculation = new();
            //calculation.Add(12, 13);
            //Calculation.Subtract(12, 3);

            //1. storing "reference of an instance method**" (name of the method acts as the refernce to that method)
            //use the instance variable since the method is instance

            //** -> its actually a reference of an instance (MethodInfo) which stores metadata of that method

            Calculation calculation = new();
            LogicInvoker addInvoker = new LogicInvoker(calculation.Add);
            //calculation.GetType().GetMethod(nameof(calculation.Add))
            //calculation

            //2. storing "reference of a static method**" (name of the method acts as the refernce to that method)
            //use the class name since the method is static

            //** -> its actually a reference of an instance (MethodInfo) which stores metadata of that method

            LogicInvoker subInvoker = Calculation.Subtract;
            //typeof(Calculation).GetMethod(nameof(Calculation.Subtract))
            //null

            //LogicInvoker calcInvoker = calculation.Add;
            //calcInvoker += Calculation.Subtract;

            //int res = calcInvoker(12, 3);
            //Console.WriteLine(res);


            //invoke the delegate to invoke method
            int addRes = addInvoker(12, 3);
            Console.WriteLine(addRes);

            int subRes = subInvoker.Invoke(12, 3);
            Console.WriteLine(subRes);
        }
    }
}
