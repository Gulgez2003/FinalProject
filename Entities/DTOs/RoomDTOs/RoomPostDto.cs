namespace Entities.DTOs.RoomDTOs
{
    public class RoomPostDto
    {
        public string? Title { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
        public int Capacity { get; set; }
        public string? BedType { get; set; }
        public string? Services { get; set; }
        public string? Description { get; set; }
        public IFormFile File { get; set; }
    }
}
