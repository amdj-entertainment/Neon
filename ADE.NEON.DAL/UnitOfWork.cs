using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL.EF;
using DbEntityValidationException = System.Data.Entity.Validation.DbEntityValidationException;

namespace ADE.NEON.DAL
{
    public class UnitOfWork : UnitOfWorkReadonly
    {
        private const string NeonContextKey = nameof(NeonContext);

        internal readonly ConcurrentDictionary<string, DbContextTransaction> ActiveTransactions;

        public UnitOfWork()
        {
            ActiveTransactions = new ConcurrentDictionary<string, DbContextTransaction>();

            ActiveTransactions.TryAdd(NeonContextKey, null);
        }

        internal override NeonContext NeonContext
        {
            get
            {
                if (_neonContext != null) return _neonContext;

                _neonContext = new NeonContext();
                ActiveTransactions[NeonContextKey] = _neonContext.Database.BeginTransaction();
                return _neonContext;
            }
        }

        public override void ClearCache()
        {
            if (_neonContext != null)
                foreach (var entry in _neonContext.ChangeTracker.Entries())
                    if (entry.Entity != null) entry.State = EntityState.Detached;
        }

        public override async Task Complete()
        {
            try
            {
                if (_neonContext != null) await _neonContext.SaveChangesAsync();

                Commit();
            }
            catch (DbEntityValidationException)
            {
                Rollback();
            }
        }

        public override void Cancel()
        {
            Rollback();
        }

        protected virtual void Commit()
        {
            foreach (var activeTransaction in ActiveTransactions.Where(x => x.Value != null).AsEnumerable())
            {
                activeTransaction.Value.Commit();
                TransactionCleanup(activeTransaction);
            }
        }

        protected virtual void Rollback()
        {
            foreach (var activeTransaction in ActiveTransactions.Where(x => x.Value != null).AsEnumerable())
            {
                activeTransaction.Value.Rollback();
                TransactionCleanup(activeTransaction);
            }
        }

        private void TransactionCleanup(KeyValuePair<string, DbContextTransaction> activeTransactionEntry)
        {
            if (activeTransactionEntry.Value == null) throw new ArgumentNullException(nameof(activeTransactionEntry));

            activeTransactionEntry.Value.Dispose();
            ActiveTransactions[activeTransactionEntry.Key] = null;
        }
    }

    public partial class UnitOfWorkReadonly : IUnitOfWork
    {
        protected bool Disposed;
        protected NeonContext _neonContext;

        internal virtual NeonContext NeonContext => _neonContext ?? (_neonContext = new NeonContext());

        public virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    _neonContext?.Dispose();
                }
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual Task Complete()
        {
            throw new NotSupportedException();
        }

        public virtual void Cancel()
        {
            throw new NotSupportedException();
        }

        public virtual void ClearCache()
        {
            throw new NotSupportedException();
        }
    }
}
