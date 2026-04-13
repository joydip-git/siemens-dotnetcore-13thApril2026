namespace BuilderPattern
{
    public class RoomBuilder
    {
        Room room = new();

        public RoomBuilder AddWalls()
        {
            room.Walls = [];
            return this;
        }

        public RoomBuilder AddDoors()
        {
            room.Doors = [];
            return this;
        }

        public RoomBuilder AddFloor()
        {
            room.Floor = new();
            return this;
        }

        public RoomBuilder AddWindows()
        {
            room.Windows = [];
            return this;
        }

        public Room BuildRoom() => room;
    }

    public class CommonHouseBuilder : IHouseBuilder
    {
        private House house = new();
        private RoomBuilder roomBuilder = new();

        public CommonHouseBuilder AddRooms()
        {
            house.Rooms =
                [
                    roomBuilder
                    .AddDoors()
                    .AddFloor()
                    .AddWindows()
                    .AddWalls()
                    .BuildRoom(),

                    roomBuilder
                    .AddDoors()
                    .AddFloor()
                    .AddWindows()
                    .AddWalls()
                    .BuildRoom(),

                    roomBuilder
                    .AddDoors()
                    .AddFloor()
                    .AddWindows()
                    .AddWalls()
                    .BuildRoom()
                ];
            return this;
        }

        public CommonHouseBuilder AddGarden()
        {
            house.Garden = new();
            return this;
        }

        public CommonHouseBuilder AddPool()
        {
            house.SwimmingPool = new();
            return this;
        }

        public CommonHouseBuilder AddGarage()
        {
            house.AddGarage(new Garage());
            return this;
        }

        public House BuildHouse() => house;
    }
}
