using Microsoft.EntityFrameworkCore;
using Net8.Data.Constants;
using Net8.Data.Context;
using Net8.Data.Entities;
using Net8.Data.Repositories.Abstract;
using Net8.Data.Repositories.Concrete;
using Net8.Data.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net8.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Net8Context _context;

        private List<TabloLog> LogTablosu;

        public ICarRepository CarRepository { get; private set; }

        public UnitOfWork(Net8Context context)
        {
            _context = context;
            CarRepository = new CarRepository(_context);

        }
        public IDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(_context);
        }
        public async Task SaveChangesAsync(string kullaniciId = null, string ipAdresi = null, bool logTutulsun = true)
        {
            await _context.SaveChangesAsync();
            if (logTutulsun)
            {
                var logKayitlari = OnBeforeSaveChanges(kullaniciId, ipAdresi);
                await _context.SaveChangesAsync();
                await OnAfterSaveChanges(logKayitlari);
            }
            else
            {
                await _context.SaveChangesAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
        private async Task OnAfterSaveChanges(List<LogKaydi> logKayitlari)
        {
            if (logKayitlari != null)
            {
                foreach (var logKaydi in logKayitlari)
                {
                    foreach (var prop in logKaydi.GeciciDegerler)
                    {
                        if (prop.Metadata.IsPrimaryKey())
                        {
                            logKaydi.IdDeger = prop.CurrentValue.ToString();
                        }
                    }
                    LogTablosu.Add(logKaydi.Logla());
                }
            }
            if (LogTablosu.Any(o => !string.IsNullOrEmpty(o.OncekiVeri) || !string.IsNullOrEmpty(o.SonrakiVeri)))
            {
                await _context.TabloLogs.AddRangeAsync(LogTablosu.Where(o => !string.IsNullOrEmpty(o.OncekiVeri) || !string.IsNullOrEmpty(o.SonrakiVeri)));
                await _context.SaveChangesAsync();
            }
        }
        private List<LogKaydi> OnBeforeSaveChanges(string kullaniciId, string ipAdresi = null)
        {
            LogTablosu = new List<TabloLog>();
            _context.ChangeTracker.DetectChanges();
            var logKayitlari = new List<LogKaydi>();
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                var logKaydi = new LogKaydi(entry);
                logKaydi.Tablo = entry.Metadata.GetTableName();

                logKaydi.KullaniciId = kullaniciId;
                logKaydi.IpAdresi = ipAdresi;
                logKayitlari.Add(logKaydi);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        logKaydi.GeciciDegerler.Add(property);
                        continue;
                    }
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        logKaydi.IdDeger = property.CurrentValue.ToString();
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            logKaydi.Islem = IslemTuruConstant.Ekleme;
                            logKaydi.YeniDeger[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            logKaydi.Islem = IslemTuruConstant.Silme;
                            logKaydi.EskiDeger[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:

                            if (property.IsModified)
                            {
                                logKaydi.Islem = IslemTuruConstant.Guncelleme;
                                if (property.OriginalValue?.ToString() != property.CurrentValue?.ToString())
                                {
                                    logKaydi.EskiDeger[propertyName] = property.OriginalValue;
                                    logKaydi.YeniDeger[propertyName] = property.CurrentValue;
                                }
                            }
                            break;
                    }
                }
            }
            foreach (var logKaydi in logKayitlari.Where(_ => !_.GeciciMi))
            {
                LogTablosu.Add(logKaydi.Logla());
            }
            return logKayitlari.Where(_ => _.GeciciMi).ToList();
        }

    }
}
