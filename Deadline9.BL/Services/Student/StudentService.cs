﻿using AutoMapper;
using Deadline9.Models;
using DeadLine9.DAL.Context;
using DeadLine9.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    public class StudentService: IStudentService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory { get; }

        public StudentService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Delete(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Student = _uow.Students.GetById(Id);
                _uow.Students.Remove(Student);
            }
        }

        public void Edit(StudentEditModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Student = Mapper.Map<Student>(model);
                _uow.Students.Update(Student);
            }
        }

        public StudentEditModel GetEditModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Student = _uow.Students.GetById(Id);
                return Mapper.Map<StudentEditModel>(Student);
            }
        }

        public void Create(StudentCreateModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Student = Mapper.Map<Student>(model);
                _uow.Students.Create(Student);
            }
        }

        public StudentDetailsModel GetDetailsModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Student = _uow.Students.GetById(Id);
                return Mapper.Map<StudentDetailsModel>(Student);
            }
        }

        public List<StudentIndexModel> GetAll()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return Mapper.Map<List<StudentIndexModel>>(_uow.Students.GetAll());
            }
        }

        public SelectList GetSelectListItems()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return new SelectList(_uow.Students.GetAll(), "Id", "Name");
            }
        }
    }
}
