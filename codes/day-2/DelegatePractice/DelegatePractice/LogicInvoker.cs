using System.Reflection;

namespace DelegatePractice
{
    //using this delegate you can any such function whose return type is "Int32" and accepts "two" arguemnus, both of type "Int32"
    public delegate int LogicInvoker(int a, int b);

    /*
    public class LogicInvoker//:MulticastDelegate:Delegate:Object
    {
        MethodInfo _method;
        object _target;
        Delegate[] _invocationList;

        public LogicInvoker(MethodInfo method, object target)
        {
            _method = method;
            _target = target;           
        }

        public int Invoke(int a, int b)
        {
            if (_target != null)
            {
               return (int) _method.Invoke(_target, new object[] { a, b });
            }
            else
                return (int)_method.Invoke(null, [a, b]);
        }
    }
    */
}
