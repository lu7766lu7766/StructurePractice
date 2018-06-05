using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositiry
{
    public class SuppliersRepository : ISuppliersRepository
    {
        protected NorthwindEntities db;

        public SuppliersRepository()
        {
            db = new NorthwindEntities();
        }
        public void Create(Suppliers instance)
        {
            throw new NotImplementedException();
        }

        public void Delete(Suppliers instance)
        {
            throw new NotImplementedException();
        }

        public Suppliers Get(string suppliersID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Suppliers> GetAll()
        {
            return db.Suppliers.OrderByDescending(x => x.SupplierID);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Suppliers instance)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置 Managed 狀態 (Managed 物件)。
                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~SuppliersRepository() {
        //   // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}