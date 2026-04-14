using System.Reflection;

namespace MapperApp
{
    public class Mapper
    {
        //method which help to Map one type to another type
        public TTarget Map<TTarget>(object source)
        {
            Type targetType = typeof(TTarget);
            Type sourceType = source.GetType();

            object? targetObject = Activator.CreateInstance(targetType);

            if (targetObject != null)
            {
                PropertyInfo[] sourceProperties = sourceType.GetProperties();
                PropertyInfo[] targetProperties = targetType.GetProperties();

                foreach (PropertyInfo sourceProperty in sourceProperties)
                {
                    //targetType.GetProperty(sourceProperty.Name)
                    foreach (PropertyInfo targetProperty in targetProperties)
                    {
                        if (sourceProperty.Name.Equals(targetProperty.Name)
                            && sourceProperty.PropertyType.Equals(targetProperty.PropertyType)
                            && targetProperty.CanWrite && sourceProperty.CanRead)
                        {
                            targetProperty.SetValue(targetObject, sourceProperty.GetValue(source));
                        }
                    }
                }
                return (TTarget)targetObject;
            }
            else
                throw new MapperException($"Mapping failed: could not create instance of {targetType.Name}");
        }
    }
}
