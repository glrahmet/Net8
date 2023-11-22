namespace Net8.Data.Entities
{
    public class TabloLog
    {
        public int Id { get; set; }
        public string TabloId { get; set; }
        public string OncekiVeri { get; set; }
        public string SonrakiVeri { get; set; }
        public string Tablo { get; set; }
        public string Islem { get; set; } 
        public DateTime IslemZamani { get; set; } 
        public string IpAdresi { get; set; }
    }
}
