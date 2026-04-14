namespace DelegateImplementation
{
    internal class Program
    {
        static List<int> Filter(List<int> input)
        {
            //filter the even numbers and return a colletion with those even numbers
            return [];
        }
        static void Main(string[] args)
        {
            List<int> numbers = [1, 5, 3, 9, 0, 6, 2, 4, 8, 7];
            List<int> output = Filter(numbers);
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}
