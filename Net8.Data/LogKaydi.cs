using Microsoft.EntityFrameworkCore.ChangeTracking;
using Net8.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net8.Data
{
    public class LogKaydi
    {
        public LogKaydi(EntityEntry kayit)
        {
            Kayit = kayit;
        }
        public EntityEntry Kayit { get; }

        public string KullaniciId { get; set; }
        public string IpAdresi { get; set; }
        public string IdDeger { get; set; }
        public string Tablo { get; set; }

        public Dictionary<string, object> EskiDeger { get; } = new Dictionary<string, object>();

        public Dictionary<string, object> YeniDeger { get; } = new Dictionary<string, object>();
        public string Islem { get; set; }
        public List<PropertyEntry> GeciciDegerler { get; } = new List<PropertyEntry>();

        public bool GeciciMi => GeciciDegerler.Any();
        public TabloLog Logla()
        {
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var log = new TabloLog(); 
            log.IslemZamani = DateTime.Now;
            log.Islem = Islem;
            log.Tablo = Tablo;
            log.TabloId = IdDeger;
            log.OncekiVeri = EskiDeger.Count == 0 ? null : JsonConvert.SerializeObject(EskiDeger, settings);
            log.SonrakiVeri = YeniDeger.Count == 0 ? null : JsonConvert.SerializeObject(YeniDeger, settings);
            log.IpAdresi = IpAdresi;
            return log;
        }
    }
}
