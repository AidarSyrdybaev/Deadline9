using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Deadline9.Models;
using DeadLine9.DAL.Entities;

namespace Deadline9.BL.AutoMapper.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            DepartmentModeltoDepartmentEntityCreate();
            SpecialityModeltoSpecialityEntityCreate();
            EntityModelToEntityCreate<TeacherCreateModel, TeacherIndexModel, TeacherDetailsModel, TeacherEditModel, Teacher>();
            EntityModelToEntityCreate<GroupCreateModel, GroupIndexModel, GroupDetailsModel, GroupEditModel, Group>();
            EntityModelToEntityCreate<StudentCreateModel, StudentIndexModel, StudentDetailsModel, StudentEditModel, Student>();
            EntityModelToEntityCreate<LessionCreateModel, LessionIndexModel, LessionDetailsModel, LessionEditModel, Lession>();
            EntityModelToEntityCreate<LectureCreateModel, LectureIndexModel, LectureDetailsModel, LectureEditModel, Lecture>();
        }

        private void DepartmentModeltoDepartmentEntityCreate()
        {
            CreateMap<DepartmentModel, Department>();
            CreateMap<Department, DepartmentModel>();
            CreateMap<DepartmentCreateModel, Department>();
        }

        private void SpecialityModeltoSpecialityEntityCreate()
        {
            CreateMap<SpecialtyCreateModel, Specialty>();
            CreateMap<Specialty, SpecialtyEditModel>();
            CreateMap<SpecialtyEditModel, Specialty>();
            CreateMap<Specialty, SpecialtyIndexModel>();
        }

        private void EntityModelToEntityCreate<CreateModel,IndexModel, DetailsModel, EditMode, Entity>()
        {
            CreateMap<CreateModel, Entity>();
            CreateMap<Entity, EditMode>();
            CreateMap<EditMode, Entity>();
            CreateMap<Entity, IndexModel>();
            CreateMap<Entity, DetailsModel>();
            CreateMap<DetailsModel, Entity>();
        }
    }
}
