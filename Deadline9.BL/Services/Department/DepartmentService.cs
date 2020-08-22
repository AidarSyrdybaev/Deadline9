using AutoMapper;
using Deadline9.Models.Department;
using DeadLine9.DAL.Context;
using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void Create(DepartmentCreateModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Department = Mapper.Map<Department>(model);
                _uow.Departments.Create(Department);

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
