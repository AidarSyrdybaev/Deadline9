using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Repositories.Contracts
{
    public interface ILectureRepository: IRepository<Lecture>
    {
        Lecture GetFullLecture(int Id);

        List<Lecture> GetLectureOnLession();
    }
}
