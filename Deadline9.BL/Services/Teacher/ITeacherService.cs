using Deadline9.Models;
using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    public interface ITeacherService
    {
        public void Delete(int Id);

        public void Edit(TeacherEditModel model);

        public TeacherEditModel GetEditModel(int Id);

        public void Create(TeacherCreateModel model);

        public TeacherDetailsModel GetDetailsModel(int Id);

        public List<TeacherIndexModel> GetAll();
    }
}
