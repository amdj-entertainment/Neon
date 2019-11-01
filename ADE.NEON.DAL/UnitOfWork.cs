using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL.EF;

namespace ADE.NEON.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        internal NeonContext NeonContext;
        internal DbContextTransaction DbContextTransaction;

        private bool _disposed;

        public virtual async Task Complete()
        {
            try
            {
                if (NeonContext != null) await NeonContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEntityValidationException)
            {
                DbContextTransaction.Rollback();
                // TODO: LOG ERRORS
                throw;
            }


        }

        public virtual void Cancel()
        {
            DbContextTransaction.Rollback();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (!disposing) return;

            DbContextTransaction?.Dispose();
            NeonContext?.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
