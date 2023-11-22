using Net8.Data.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net8.Data.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {  
        IDatabaseTransaction BeginTransaction();
        Task SaveChangesAsync(string kullaniciId = null, string ipAdresi = null, bool logTutulsun = true);
    }
}
