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
    public class TeacherService: ITeacherService
    {   
        private IUnitOfWorkFactory _unitOfWorkFactory { get; }
        public TeacherService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Delete(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Teacher = _uow.Teachers.GetById(Id);
                _uow.Teachers.Remove(Teacher);
            }
        }

        public void Edit(TeacherEditModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Teacher = Mapper.Map<Teacher>(model);
                _uow.Teachers.Update(Teacher);
            }
        }

        public TeacherEditModel GetEditModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Speciality = _uow.Teachers.GetById(Id);
                return Mapper.Map<TeacherEditModel>(Speciality);
            }
        }

        public void Create(TeacherCreateModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Teacher = Mapper.Map<Teacher>(model);
                _uow.Teachers.Create(Teacher);
            }
        }

        public TeacherDetailsModel GetDetailsModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Teacher = _uow.Teachers.GetById(Id);
                return Mapper.Map<TeacherDetailsModel>(Teacher);
            }
        }

        public List<TeacherIndexModel> GetAll()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return Mapper.Map<List<TeacherIndexModel>>(_uow.Teachers.GetAll());
            }
        }

        public SelectList GetSelectListItems()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return new SelectList(_uow.Teachers.GetAll(), "Id", "Name");
            }
        }
    }
}
