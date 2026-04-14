namespace FunctionalProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];

            //1. sort the numbers in descending order
            IOrderedEnumerable<int> sortedNumbers = numbers.OrderByDescending(num => num);

            //2. filter only even numbers
            IEnumerable<int> filteredNumbers = sortedNumbers.Where(num => num % 2 == 0);

            //3. multiply every even number by 5
            IEnumerable<int> multipliedNumbers = filteredNumbers.Select(num => num * 5);

            //4. take the first 3 values
            IEnumerable<int> selectedValues = multipliedNumbers.Take(3);

            //5. print them
            /*
             * public delegate void Action<in T>(T obj) where T : allows ref struct;
             */

            //Action<int> printDel = (num) => Console.WriteLine(num);
            selectedValues.ToList<int>().ForEach((num) => Console.WriteLine(num));
        }
    }
}
