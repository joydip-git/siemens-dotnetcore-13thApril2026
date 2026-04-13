namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommonHouseBuilder houseBuilder = new();
            House house = houseBuilder.BuildHouse();

            Console.WriteLine(house.SwimmingPool == null ? "Pool NA" : "Pool available");
            Console.WriteLine(house.Garden == null ? "Garden NA" : "Garden available");

            house = houseBuilder
                .AddGarden()
                .AddPool()
                .BuildHouse();

            house = houseBuilder
                .AddGarage()
                .AddX()
                .BuildHouse();

            Console.WriteLine(house.SwimmingPool == null ? "Pool NA" : "Pool available");
            Console.WriteLine(house.Garden == null ? "Garden NA" : "Garden available");
        }
    }
}
