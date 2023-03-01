namespace Entities.DTOs.ReservationDTOs
{
    public class ReservationCreateDto
    {
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Message { get; set; }
		public string? Room { get; set; }
		public int NumberOfAdults { get; set; }
		public int NumberOfChildren { get; set; }
		public int NumberOfInfants { get; set; }
        public string ArrivalDate { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public DateTime ArrivalDateTime => DateTime.ParseExact($"{ArrivalDate.Replace(" ", "")} {ArrivalTime}", "MM/dd/yyyy h : mm tt", CultureInfo.InvariantCulture);
        public DateTime DepartureDateTime => DateTime.ParseExact($"{DepartureDate.Replace(" ", "")} {DepartureTime}", "MM/dd/yyyy h : mm tt", CultureInfo.InvariantCulture);
    }
}