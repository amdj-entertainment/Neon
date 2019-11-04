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
        private AuthContext _authContext;

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
                case DatabaseContext.Auth:
                    _unitOfWork = new UnitOfWork();
                    _authContext = new AuthContext();

                    _unitOfWork.AuthContext = _authContext;
                    _unitOfWork.DbContextTransaction = _authContext.Database.BeginTransaction();

                    return _unitOfWork;
                default:
                    throw new InvalidOperationException("Invalid Database Context");
            }
        }
    }
}
