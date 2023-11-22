
namespace Net8.Data.Entities
{
    public class Testimonial : BaseEntity
    { 
        public string TestimonialName { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
