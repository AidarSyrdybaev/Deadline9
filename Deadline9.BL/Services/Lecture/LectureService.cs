using AutoMapper;
using Deadline9.Models;
using DeadLine9.DAL.Context;
using DeadLine9.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    public class LectureService: ILectureService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory { get; }

        public LectureService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Delete(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Lecture = _uow.Lectures.GetById(Id);
                _uow.Lectures.Remove(Lecture);
            }
        }

        public void Edit(LectureEditModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Lecture = Mapper.Map<Lecture>(model);
                _uow.Lectures.Update(Lecture);
            }
        }

        public LectureEditModel GetEditModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Lession = _uow.Lectures.GetById(Id);
                return Mapper.Map<LectureEditModel>(Lession);
            }
        }

        public void Create(LectureCreateModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Lecture = Mapper.Map<Lecture>(model);
                _uow.Lectures.Create(Lecture);
            }
        }

        public LectureDetailsModel GetDetailsModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Lecture = _uow.Lectures.GetFullLecture(Id);
                return Mapper.Map<LectureDetailsModel>(Lecture);
            }
        }

        public List<LectureIndexModel> GetAll()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return Mapper.Map<List<LectureIndexModel>>(_uow.Lectures.GetLectureOnLession());
            }
        }
    }
}
