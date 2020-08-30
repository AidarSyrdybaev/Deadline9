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
    public class LessionService: ILessionService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory { get; }

        public LessionService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Delete(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Lession = _uow.Lessions.GetById(Id);
                _uow.Lessions.Remove(Lession);
            }
        }

        public void Edit(LessionEditModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Lession = Mapper.Map<Lession>(model);
                _uow.Lessions.Update(Lession);
            }
        }

        public LessionEditModel GetEditModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Lession = _uow.Lessions.GetById(Id);
                return Mapper.Map<LessionEditModel>(Lession);
            }
        }

        public void Create(LessionCreateModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Lession = Mapper.Map<Lession>(model);
                _uow.Lessions.Create(Lession);
            }
        }

        public LessionDetailsModel GetDetailsModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Lession = _uow.Lessions.GetById(Id);
                return Mapper.Map<LessionDetailsModel>(Lession);
            }
        }

        public List<LessionIndexModel> GetAll()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return Mapper.Map<List<LessionIndexModel>>(_uow.Lessions.GetAll());
            }
        }

        public SelectList GetSelectListItems()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return new SelectList(_uow.Lessions.GetAll(), "Id", "Name");
            }
        }
    }
}
