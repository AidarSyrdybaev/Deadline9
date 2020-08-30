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
    public class PointService: IPointService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory { get; }

        public PointService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Delete(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Point = _uow.Points.GetById(Id);
                _uow.Points.Remove(Point);
            }
        }

        public void Edit(PointEditModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Point = Mapper.Map<Point>(model);
                _uow.Points.Update(Point);
            }
        }

        public PointEditModel GetEditModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Point = _uow.Points.GetById(Id);
                return Mapper.Map<PointEditModel>(Point);
            }
        }

        public void Create(PointCreateModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Point = Mapper.Map<Point>(model);
                _uow.Points.Create(Point);
            }
        }

        public PointDetailsModel GetDetailsModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Point = _uow.Points.GetFullPoint(Id);
                return Mapper.Map<PointDetailsModel>(Point);
            }
        }

        public List<PointIndexModel> GetAll()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return Mapper.Map<List<PointIndexModel>>(_uow.Points.GetFullPoints());
            }
        }

        public SelectList GetSelectListItems()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return new SelectList(_uow.Points.GetAll(), "Id", "Name");
            }
        }
    }
}
