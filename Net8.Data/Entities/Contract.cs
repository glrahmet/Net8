namespace Net8.Data.Entities
{
    public class Contract : BaseEntity
    { 
        public string ContractName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
