namespace Entities.Concrete
{
    public class Room : IEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
        public int Capacity { get; set; }
        public string? BedType { get; set; }
        public string? Services { get; set; }
        public string? Description { get; set; }
        public string? ImageName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAvailable { get; set; }
    }
}
