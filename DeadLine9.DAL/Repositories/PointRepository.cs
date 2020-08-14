using DeadLine9.DAL.Context;
using DeadLine9.DAL.Entities;
using DeadLine9.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Repositories
{
    public class PointRepository : Repository<Point>, IPointRepository
    {
        public PointRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            entities = applicationDbContext.Points;
        }
    }
}
