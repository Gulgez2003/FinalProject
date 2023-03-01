namespace Entities.Concrete
{
    public class Testimonial:IEntity
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
        public string CustomerName { get; set; }
    }
}
