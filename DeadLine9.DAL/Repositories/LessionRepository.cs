using DeadLine9.DAL.Context;
using DeadLine9.DAL.Entities;
using DeadLine9.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Repositories
{
    public class LessionRepositoryy : Repository<Lession>, ILessionRepository
    {
        public LessionRepositoryy(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            entities = applicationDbContext.Lessions;
        }
    }
}
