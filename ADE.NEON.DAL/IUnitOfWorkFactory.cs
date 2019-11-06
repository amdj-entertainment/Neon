using ADE.NEON.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.DAL
{
    public interface IUnitOfWorkFactory
    {
        UnitOfWork CreateUnitOfWork();
    }
}
