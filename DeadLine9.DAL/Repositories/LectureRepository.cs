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
    public class LectureRepository:Repository<Lecture>, ILectureRepository
    {
        public LectureRepository(ApplicationDbContext applicationDbContext): base(applicationDbContext)
        {
            entities = applicationDbContext.Lectures;
        }

        public Lecture GetFullLecture(int Id)
        {
            return entities.Where(i => i.Id == Id).Include(i => i.Lession).Include(i => i.Teacher).Include(i => i.Group).First();
        }

        public List<Lecture> GetLectureOnLession()
        {
            return entities.Include(i => i.Lession).ToList();
        }
    }
}
