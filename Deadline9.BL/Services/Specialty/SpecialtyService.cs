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
    public class SpecialtyService: ISpecialtyService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory { get; }

        public SpecialtyService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Delete(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Specialty = _uow.Specialities.GetById(Id);
                _uow.Specialities.Remove(Specialty);
            }
        }

        public void Edit(SpecialtyEditModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Specialty = Mapper.Map<Specialty>(model);
                _uow.Specialities.Update(Specialty);
            }
        }

        public SpecialtyEditModel GetSpecialityEditModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Speciality = _uow.Specialities.GetById(Id);
                return Mapper.Map<SpecialtyEditModel>(Speciality);
            }
        }

        public void Create(SpecialtyCreateModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Speciality = Mapper.Map<Specialty>(model);
                _uow.Specialities.Create(Speciality);
            }
        }

        public void Details(int Id)
        {

        }

        public List<SpecialtyIndexModel> GetAll()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return Mapper.Map<List<SpecialtyIndexModel>>(_uow.Specialities.GetAll());
            }
        }
    }
}
