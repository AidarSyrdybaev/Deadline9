using Deadline9.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    interface IStudentService
    {
        public void Delete(int Id);

        public void Edit(StudentEditModel model);

        public StudentEditModel GetEditModel(int Id);

        public void Create(StudentCreateModel model);

        public StudentDetailsModel GetDetailsModel(int Id);

        public List<StudentIndexModel> GetAll();
    }
}
