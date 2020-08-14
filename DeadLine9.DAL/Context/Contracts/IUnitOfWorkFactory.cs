using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Context
{
    public interface IUnitOfWorkFactory
    {
        UnitOfWork Create();
    }
}
