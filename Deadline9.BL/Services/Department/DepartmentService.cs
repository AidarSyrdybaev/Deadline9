using AutoMapper;
using Deadline9.Models;
using DeadLine9.DAL.Context;
using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Deadline9.BL.Services
{
    public class DepartmentService: IDepartmentService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory { get; }

        public DepartmentService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Delete(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Department = _uow.Departments.GetById(Id);
                _uow.Departments.Remove(Department);
            }
        }

        public void Edit(DepartmentModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Department = Mapper.Map<Department>(model);
                _uow.Departments.Update(Department);
            }
        }

        public DepartmentModel GetDepartmentModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Department = _uow.Departments.GetById(Id);
                return Mapper.Map<DepartmentModel>(Department);
            }
        }

        public void Create(DepartmentCreateModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Department = Mapper.Map<Department>(model);
                _uow.Departments.Create(Department);

            }
        }

        public SelectList GetDepartmentsSelectListItems()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                SelectList Departments = new SelectList(_uow.Departments.GetAll(), "Id", "Name");
                return Departments;
            }
        }

        public void Details(int Id)
        { 
        
        }

        public List<DepartmentModel> GetAll()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return Mapper.Map<List<DepartmentModel>>(_uow.Departments.GetAll());
            }
        }
    }
}
