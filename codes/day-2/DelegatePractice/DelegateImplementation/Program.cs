namespace DelegateImplementation
{
    //internal delegate bool FuncInvoker(int x);
    //public delegate bool FuncInvoker<in TInput>(TInput x);
    //internal delegate TResult FuncInvoker<in TInput, out TResult>(TInput x);
    //internal delegate TResult FuncInvoker<in TInput1, in TInput2, out TResult>(TInput1 x, TInput2 y);
    //internal delegate T3 FuncInvoker<T1, T2, T3>(T1 x, T2 y);
    internal class Program
    {
        //problem: the function contains the logic about "how to filter"
        //requirement: function should not have the logic of "how to filter"
        //solution: pass the method or an anonymous method with logic of "how to filter" through a delegate to the Filter method
        //advantage: the method is now decoupled from the actula business logic

        //the function works only on "int" type
        //requirement: function should work on any type of collection and be able to filter
        //solution: use generic function
        //static List<TElement> Filter<TElement>(List<TElement> input, FuncInvoker<TElement> logicInvoker)
        //{
        //    List<TElement> result = [];
        //    foreach (TElement item in input)
        //    {
        //        if (logicInvoker(item))
        //            result.Add(item);
        //    }
        //    return result;
        //}
        static void Main(string[] args)
        {

            List<int> numbers = [1, 5, 3, 9, 0, 6, 2, 4, 8, 7];
            List<string> names = ["anil", "sunil", "joy"];

            /*
            //inline anonymous method (assignable ONLY to delegate)
            //FuncInvoker evenLogic = delegate (int num)
            //{
            //    return num % 2 == 0;
            //};

            //Lambda expression-> short hand notation or expression or declarative syntax for anonymous method which uses expression body syntax also
            // => --> lambda operator
            //left side of lamda operator -> argument list for the function body
            //right side of lambda operator -> function body or expression body
            FuncInvoker<int> evenLogic = (int num) =>
            {
                return num % 2 == 0;
            };

            //num "goes to" the expression body num % 2 != 0
            FuncInvoker<int> oddLogic = (num) => num % 2 != 0;

            //List<int> output = Filter(numbers, evenLogic);
            List<int> output = Filter<int>(numbers, oddLogic);
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }

            
            //FuncInvoker<string> containsNLogic = delegate (string name)
            //{
            //    return name.ToLower().Contains("n");
            //};
            FuncInvoker<string> containsNLogic = (name) => name.ToLower().Contains("n");
            List<string> filteredNames = Filter<string>(names, containsNLogic);
            foreach (var item in filteredNames)
            {
                Console.WriteLine(item);
            }
            */
            //var evenNumbers = numbers.Filter((num) => num > 5);
            //var namesWithN = names.Filter((name) => name.ToLower().Contains('u'));

            Func<int, bool> isEven = (num) => num % 2 == 0;
            var evenNumbers = numbers.Where(isEven);

            Func<string, bool> containsN = (name) => name.ToLower().Contains('u');
            var namesWithN = names.Where(containsN);

            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }

            foreach (var item in namesWithN)
            {
                Console.WriteLine(item);
            }
        }
    }
}
