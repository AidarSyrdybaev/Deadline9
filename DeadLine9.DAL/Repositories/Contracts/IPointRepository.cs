using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Repositories.Contracts
{
    public interface IPointRepository: IRepository<Point>
    {
        public Point GetFullPoint(int Id);
        public List<Point> GetFullPoints();
    }
}
