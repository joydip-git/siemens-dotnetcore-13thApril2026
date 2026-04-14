namespace ReflectionLibrary
{
    public class Calculation : ICalculation
    {
        private int result;

        //expression bodied expression for readonly property
        //public int Result {  get { return result; } }
        public int Result => result;

        public void Add(int x, int y)
        {
            result = x + y;
        }
    }
}
