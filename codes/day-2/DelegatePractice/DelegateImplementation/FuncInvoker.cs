namespace DelegateImplementation
{
    public delegate bool FuncInvoker<in TInput>(TInput x) where TInput : allows ref struct;
    //  public delegate bool Predicate<in T>(T obj) where T : allows ref struct;

    //public delegate TResult Func<out TResult>();
    //public delegate TResult Func<in T, out TResult>(T x);
    //public delegate TResult Func<in T1, in T2, out TResult>(T1 x, T2 y);
    //....
    //public delegate TResult Func<in T1,...,in T16, out TResult>(T1 arg1, ....,T16 arg16);
}
