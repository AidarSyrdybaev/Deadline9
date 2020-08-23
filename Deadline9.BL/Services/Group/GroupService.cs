using AutoMapper;
using Deadline9.Models;
using DeadLine9.DAL.Context;
using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    public class GroupService: IGroupService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory { get; }

        public GroupService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Delete(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Group = _uow.Groups.GetById(Id);
                _uow.Groups.Remove(Group);
            }
        }

        public void Edit(GroupEditModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Group = Mapper.Map<Group>(model);
                _uow.Groups.Update(Group);
            }
        }

        public GroupEditModel GetEditModel(int Id)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Speciality = _uow.Groups.GetById(Id);
                return Mapper.Map<GroupEditModel>(Speciality);
            }
        }

        public void Create(GroupCreateModel model)
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                var Group = Mapper.Map<Group>(model);
                _uow.Groups.Create(Group);
            }
        }

        public void Details(int Id)
        {

        }

        public List<GroupIndexModel> GetAll()
        {
            using (var _uow = _unitOfWorkFactory.Create())
            {
                return Mapper.Map<List<GroupIndexModel>>(_uow.Groups.GetAll());
            }
        }
    }
}
