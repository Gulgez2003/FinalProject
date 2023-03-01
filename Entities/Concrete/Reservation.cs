namespace Entities.Concrete
{
    public class Reservation : IEntity
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Message { get; set; }
        public DateTime ArrivalDateTime { get; set; }   
        public DateTime DepartureDateTime { get; set;}
        public string? Room { get; set; }
        public int NumberOfAdults { get; set;}
        public int NumberOfChildren { get; set;}
        public int NumberOfInfants { get; set;}
    }
}
