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

        public UnitOfWork CreateUnitOfWork()
        {
            _unitOfWork = new UnitOfWork();

            return _unitOfWork;
        }
    }
}
