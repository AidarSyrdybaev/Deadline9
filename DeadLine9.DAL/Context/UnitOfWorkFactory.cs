using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Context
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;

        public UnitOfWorkFactory(IApplicationDbContextFactory applicationDbContextFactory)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
        }

        public UnitOfWork Create()
        {
            return new UnitOfWork(_applicationDbContextFactory.Create());
        }
    }
}
