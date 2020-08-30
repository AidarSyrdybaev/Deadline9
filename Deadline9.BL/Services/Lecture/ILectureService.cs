using Deadline9.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    public interface ILectureService
    {
        public void Delete(int Id);
        public void Edit(LectureEditModel model);
        public LectureEditModel GetEditModel(int Id);
        public void Create(LectureCreateModel model);
        public LectureDetailsModel GetDetailsModel(int Id);
        public List<LectureIndexModel> GetAll();
    }
}
