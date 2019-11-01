using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL.EF;

namespace ADE.NEON.DAL
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public UnitOfWork CreateUnitOfWork()
        {
            var unitOfWork = new UnitOfWork();
            var neonContext = new NeonContext();

            unitOfWork.NeonContext = neonContext;
            unitOfWork.DbContextTransaction = neonContext.Database.BeginTransaction();

            return unitOfWork;
        }
    }
}
