namespace BuilderPattern
{
    public static class HouseBuilderExtensions
    {
        public static IHouseBuilder AddX(this IHouseBuilder builder)
        {
            //add some feature in the house using builder
            //House house =builder.BuildHouse();
            //house.someprop = someobj;
            return builder;
        }
    }
}
