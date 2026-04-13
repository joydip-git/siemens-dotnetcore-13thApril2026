namespace BuilderPattern
{

    public class Room
    {
        public ICollection<Window> Windows { get; set; }
        public Floor Floor { get; set; }
        public ICollection<Wall> Walls { get; set; }
        public ICollection<Door> Doors { get; set; }
    }

    public class House
    {
        public ICollection<Room> Rooms { get; set; } = [];
        public Garden? Garden { get; set; }
        public SwimmingPool? SwimmingPool { get; set; }
    }

    /*
    public class HouseWithGarden : House
    {
        public Garden Garden { get; set; }
    }

    public class HouseWithGardenAndSwimmingPool : HouseWithGarden
    {
        public SwimmingPool SwimmingPool { get; set; }
    }
    */
}
