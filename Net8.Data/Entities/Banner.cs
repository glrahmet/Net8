namespace Net8.Data.Entities
{
    public class Banner: BaseEntity
    {       
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
