using System.Reflection;

namespace ReflectionClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Assembly assembly = LoadAssembly(@"E:\trainings\siemens-dotnetcore-13thApril2026\codes\day-2\ReflectionDemo\ReflectionLibrary\bin\Debug\net10.0\ReflectionLibrary.dll");
                Console.WriteLine($"Name: {assembly.FullName}");

                DiscoverTypes(assembly);
                object? obj = DiscoverClassTypeAndCreateInstance("ReflectionLibrary.Calculation", assembly);
                if (obj != null)
                {
                    DiscoverMethodAndInvoke(obj);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static Assembly LoadAssembly(string path)
        {
            if (File.Exists(path))
            {
                Assembly loadedAssembly = Assembly.LoadFile(path);
                return loadedAssembly;
            }
            else
                throw new FileNotFoundException($"file not found at the path {path}");
        }
        static void DiscoverTypes(Assembly assembly)
        {
            Type[] allTypes = assembly.GetTypes();
            foreach (Type type in allTypes)
            {
                Console.WriteLine($"Name={type.Name}");
                Console.WriteLine($"Is class={type.IsClass}");
                Console.WriteLine($"Is Interface={type.IsInterface}");
                Console.WriteLine($"Is Value type={type.IsValueType}");
                Console.WriteLine(Environment.NewLine);
            }
        }
        static object? DiscoverClassTypeAndCreateInstance(string fullName, Assembly assembly)
        {
            Type? clsMetadata = assembly.GetType(fullName);
            if (clsMetadata != null)
            {
                //the class must have a default constructor
                object? obj = Activator.CreateInstance(clsMetadata);
                return obj;
            }
            else
                throw new NullReferenceException("the instance could not be created...");
        }
        static void DiscoverMethodAndInvoke(object obj)
        {
            Type classMetadata = obj.GetType();

            DiscoverFieldsOfType(classMetadata);
            DiscoverMethodsOfType(classMetadata);
            DiscoverPropertiesOfType(classMetadata);

            MethodInfo? addmethod = classMetadata.GetMethod("Add", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            if (addmethod != null)
            {
                if (!addmethod.IsStatic)
                {
                    object? output = addmethod.Invoke(obj, new object[] { 12, 13 });
                    if (output == null)
                    {
                        PropertyInfo? resultPropInfo = classMetadata.GetProperty("Result");

                        if (resultPropInfo != null)
                        {
                            //resultPropInfo.SetValue(obj, 25);
                            output = resultPropInfo.GetValue(obj);
                            Console.WriteLine(output);
                        }
                    }
                }
                //else
                //{
                //    object? output = addmethod.Invoke(null, new object[] { 12, 13 });
                //    Console.WriteLine(output ?? "NA");
                //}
            }
        }

        private static void DiscoverPropertiesOfType(Type classMetadata)
        {
            PropertyInfo[] allProperties = classMetadata.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            foreach (PropertyInfo item in allProperties)
            {
                Console.WriteLine($"\nProperty Name={item.Name}");
                Console.WriteLine($"Property Type={item.PropertyType}");
                Console.WriteLine($"Can Read ={item.CanRead}");
                Console.WriteLine($"Can Write ={item.CanWrite}");
            }
        }

        private static void DiscoverMethodsOfType(Type classMetadata)
        {
            MethodInfo[] allMethods = classMetadata.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            foreach (MethodInfo item in allMethods)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Method Name={item.Name}");
                Console.WriteLine($"Method return type={item.ReturnType}");
                DiscoverParametersOfMethod(item);

                Console.WriteLine("\n");
            }
        }

        private static void DiscoverParametersOfMethod(MethodInfo item)
        {
            ParameterInfo[] parameters = item.GetParameters();
            if (parameters.Length > 0)
            {
                Console.WriteLine("\n");
                foreach (ParameterInfo parameter in parameters)
                {
                    Console.WriteLine($"Paramater Name={parameter.Name}");
                    Console.WriteLine($"Parameter Type={parameter.ParameterType}");
                    Console.WriteLine($"Paraneter position={parameter.Position}");
                }
                Console.WriteLine("\n");
            }
            else
                Console.WriteLine($"\n{item.Name} method does not have any parameters");
        }

        private static void DiscoverFieldsOfType(Type classMetadata)
        {
            FieldInfo[] allFields = classMetadata.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo item in allFields)
            {
                Console.WriteLine($"\nField Name={item.Name}");
                Console.WriteLine($"Field data Type={item.FieldType}");
            }
        }
    }
}
