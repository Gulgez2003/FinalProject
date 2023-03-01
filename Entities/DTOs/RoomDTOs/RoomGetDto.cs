namespace Entities.DTOs.RoomDTOs
{
    public class RoomGetDto
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
    }
}
