namespace MapperApp
{
    public class MapperException : ApplicationException
    {
        public MapperException():base("Mapping failed")
        {
            
        }
        public MapperException(string errorMessage):base(errorMessage)
        {
            
        }
    }
}
