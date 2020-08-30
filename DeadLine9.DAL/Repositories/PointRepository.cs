using DeadLine9.DAL.Context;
using DeadLine9.DAL.Entities;
using DeadLine9.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadLine9.DAL.Repositories
{
    public class PointRepository : Repository<Point>, IPointRepository
    {
        public PointRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            entities = applicationDbContext.Points;
        }

        public Point GetFullPoint(int Id)
        {
            return entities.Include(i => i.Student).Where(i => i.Id == Id).FirstOrDefault();
        }

        public List<Point> GetFullPoints()
        {
            return entities.Include(i => i.Student).ToList();
        }
    }
}
