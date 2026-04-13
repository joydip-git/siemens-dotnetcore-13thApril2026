namespace BuilderPattern
{
    public interface IHouseBuilder
    {
        CommonHouseBuilder AddGarage();
        CommonHouseBuilder AddGarden();
        CommonHouseBuilder AddPool();
        CommonHouseBuilder AddRooms();
        House BuildHouse();
    }
}