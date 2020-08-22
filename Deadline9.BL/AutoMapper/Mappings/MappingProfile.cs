using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Deadline9.Models.Department;
using DeadLine9.DAL.Entities;

namespace Deadline9.BL.AutoMapper.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            DepartmentModeltoDepartmentEntityCreate();
        }

        private void DepartmentModeltoDepartmentEntityCreate()
        {
            CreateMap<DepartmentModel, Department>();
            CreateMap<Department, DepartmentModel>();
            CreateMap<DepartmentCreateModel, Department>();
        }
    }
}
