namespace DelegateImplementation
{
    public static class CollectionExtensions
    {
        public static IEnumerable<TElement> Filter<TElement>(this IEnumerable<TElement> list, FuncInvoker<TElement> logic)
        {
            List<TElement> result = [];
            foreach (var item in list)
            {
                if (logic(item))
                    result.Add(item);
            }
            return result;
        }
    }
}
