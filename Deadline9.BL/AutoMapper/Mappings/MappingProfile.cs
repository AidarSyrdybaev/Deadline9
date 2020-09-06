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
            GroupModelToGroupEntityCreate();
            PointModelToPointEntityCreate();
            EntityModelToEntityCreate<StudentCreateModel, StudentIndexModel, StudentDetailsModel, StudentEditModel, Student>();
            EntityModelToEntityCreate<LessionCreateModel, LessionIndexModel, LessionDetailsModel, LessionEditModel, Lession>();
            EntityModelToEntityCreate<LectureCreateModel, LectureIndexModel, LectureDetailsModel, LectureEditModel, Lecture>();
            EntityModelToEntityCreate<TeacherCreateModel, TeacherIndexModel, TeacherDetailsModel, TeacherEditModel, Teacher>();

        }

        private void GroupModelToGroupEntityCreate()
        {
            CreateMap<GroupCreateModel, Group>();
            CreateMap<Group, GroupEditModel>();
            CreateMap<GroupEditModel, Group>();
            CreateMap<Group, GroupIndexModel>();
            CreateMap<Group, GroupDetailsModel>()
                .ForMember(src => src.SpecialityName, target => target.MapFrom(source => source.Specialty.Name));
            CreateMap<GroupDetailsModel, Group>();
        }

        private void PointModelToPointEntityCreate()
        {
            CreateMap<PointCreateModel, Point>();
            CreateMap<Point, PointEditModel>();
            CreateMap<PointEditModel, Point>();
            CreateMap<Point, PointIndexModel>()
                .ForMember(src => src.StudentName, target => target.MapFrom(source => source.Student.Surname + " " +  source.Student.Name + " " + source.Student.LastName));
            CreateMap<Point, PointDetailsModel>()
                .ForMember(src => src.StudentName, target => target.MapFrom(source => source.Student.Surname + " " + source.Student.Name + " " + source.Student.LastName));
            CreateMap<PointDetailsModel, Point>();
        }

        private void LectureModelToLectureEntityCreate()
        {
            CreateMap<LectureCreateModel, Lecture>();
            CreateMap<Lecture, LectureEditModel>();
            CreateMap<LectureEditModel, Lecture>();
            CreateMap<Lecture, LectureIndexModel>()
                .ForMember(src => src.LessionName, target => target.MapFrom(source => source.Lession.Name));
            CreateMap<Lecture, LectureDetailsModel>()
                .ForMember(src => src.GroupName, target => target.MapFrom(source => source.Group.Name))
                .ForMember(src => src.LessionName, target => target.MapFrom(source => source.Lession.Name))
                .ForMember(src => src.TeacherName, target => target.MapFrom(source => source.Teacher.Surname + " " + source.Teacher.Name + " " + source.Teacher.LastName));
            CreateMap<LectureDetailsModel, Lecture>();
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

        private void EntityModelToEntityCreate<CreateModel,IndexModel, DetailsModel, EditModel, Entity>()
        {
            CreateMap<CreateModel, Entity>();
            CreateMap<Entity, EditModel>();
            CreateMap<EditModel, Entity>();
            CreateMap<Entity, IndexModel>();
            CreateMap<Entity, DetailsModel>();
            CreateMap<DetailsModel, Entity>();
        }
    }
}
