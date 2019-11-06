using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADE.NEON.DAL.EF;
using ADE.NEON.Shared.Enums;

namespace ADE.NEON.DAL
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private UnitOfWork _unitOfWork;
        private NeonContext _neonContext;

        public UnitOfWork CreateUnitOfWork(DatabaseContext database)
        {
            switch (database)
            {
                case DatabaseContext.Neon:
                    _unitOfWork = new UnitOfWork();
                    _neonContext = new NeonContext();

                    _unitOfWork.NeonContext = _neonContext;
                    _unitOfWork.DbContextTransaction = _neonContext.Database.BeginTransaction();

                    return _unitOfWork;
                default:
                    throw new InvalidOperationException("Invalid Database Context");
            }
        }
    }
}
