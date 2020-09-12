using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Deadline9.BL.Services;
using Deadline9.UI.Controllers;
using Deadline9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeadLine9.DAL.Entities;

namespace Deadline9.Tests
{
    public class LectureControllerTest
    {
        [Fact]
        public async Task IndexTest()
        {
            //    ILectureService _lectureService { get; }
            //private IGroupService _groupService { get; }
            //private ITeacherService _teacherService { get; }
            //private ILessionService _lessionService { get; }

            var LectureServiceMock = new Mock<ILectureService>();
            var GroupServiceMock = new Mock<IGroupService>();
            var TeacherServiceMock = new Mock<ITeacherService>();
            var LessionServiceMock = new Mock<ILessionService>();

            LectureServiceMock.Setup(repo => repo.GetAll()).Returns(GetLectureIndexModels());

            var LectureController = new LectureController(LectureServiceMock.Object, GroupServiceMock.Object, TeacherServiceMock.Object, LessionServiceMock.Object);

            var Result = await LectureController.Index();

            var ViewResult = Assert.IsType<ViewResult>(Result);

            var Model = Assert.IsAssignableFrom<List<LectureIndexModel>>(ViewResult.Model);

            Assert.Equal(Model.Count, GetLectureIndexModels().Count);

        }

        [Fact]

        public async Task DetailsTest()
        {
            var LectureServiceMock = new Mock<ILectureService>();
            var GroupServiceMock = new Mock<IGroupService>();
            var TeacherServiceMock = new Mock<ITeacherService>();
            var LessionServiceMock = new Mock<ILessionService>();

            LectureServiceMock.Setup(repo => repo.GetDetailsModel(1)).Returns(GetDetailsModel(1));

            var LectureController = new LectureController(LectureServiceMock.Object, GroupServiceMock.Object, TeacherServiceMock.Object, LessionServiceMock.Object);

            var Result = await LectureController.Details(1);

            var ViewResult = Assert.IsType<ViewResult>(Result);

            var Model = Assert.IsAssignableFrom<LectureDetailsModel>(ViewResult.Model);

            Assert.Equal(Model.TeacherName, GetDetailsModel(1).TeacherName);
        }


        [Fact]

        public async Task GetCreateTest()
        {
            var LectureServiceMock = new Mock<ILectureService>();
            var GroupServiceMock = new Mock<IGroupService>();
            var TeacherServiceMock = new Mock<ITeacherService>();
            var LessionServiceMock = new Mock<ILessionService>();

            GroupServiceMock.Setup(repo => repo.GetSelectListItems()).Returns(GetGroupSelectListItems());
            TeacherServiceMock.Setup(repo => repo.GetSelectListItems()).Returns(GetTeacherSelectListItems());
            LessionServiceMock.Setup(repo => repo.GetSelectListItems()).Returns(GetLessionSelectListItems());

            var LectureController = new LectureController(LectureServiceMock.Object, GroupServiceMock.Object, TeacherServiceMock.Object, LessionServiceMock.Object);

            var Result = LectureController.Create();

            Assert.NotNull(Result);

        }
        [Fact]
        public async Task PostCreateTest()
        {
            var LectureServiceMock = new Mock<ILectureService>();
            var GroupServiceMock = new Mock<IGroupService>();
            var TeacherServiceMock = new Mock<ITeacherService>();
            var LessionServiceMock = new Mock<ILessionService>();

            LectureServiceMock.Setup(repo => repo.Create(null)).Callback((LectureCreateModel model) => { } );

            var LectureController = new LectureController(LectureServiceMock.Object, GroupServiceMock.Object, TeacherServiceMock.Object, LessionServiceMock.Object);

            var Result = await LectureController.Create(null);

            Assert.NotNull(Result);
        }

        [Fact]
        public async Task GetEditTest()
        {
            var LectureServiceMock = new Mock<ILectureService>();
            var GroupServiceMock = new Mock<IGroupService>();
            var TeacherServiceMock = new Mock<ITeacherService>();
            var LessionServiceMock = new Mock<ILessionService>();

            GroupServiceMock.Setup(repo => repo.GetSelectListItems()).Returns(GetGroupSelectListItems());
            TeacherServiceMock.Setup(repo => repo.GetSelectListItems()).Returns(GetTeacherSelectListItems());
            LessionServiceMock.Setup(repo => repo.GetSelectListItems()).Returns(GetLessionSelectListItems());
            LectureServiceMock.Setup(repo => repo.GetEditModel(1)).Returns(LectureGetEditModelMockMethod(1));

            var LectureController = new LectureController(LectureServiceMock.Object, GroupServiceMock.Object, TeacherServiceMock.Object, LessionServiceMock.Object);

            var Result = await LectureController.Edit(1);

            var ViewResult = Assert.IsType<ViewResult>(Result);

            var Model = Assert.IsAssignableFrom<LectureEditModel>(ViewResult.Model);

            Assert.Equal(Model.Id, LectureGetEditModelMockMethod(1).Id);

        }

        [Fact]
        public async Task PostEditTest()
        {
            var LectureServiceMock = new Mock<ILectureService>();
            var GroupServiceMock = new Mock<IGroupService>();
            var TeacherServiceMock = new Mock<ITeacherService>();
            var LessionServiceMock = new Mock<ILessionService>();

            LectureServiceMock.Setup(repo => repo.Edit(new LectureEditModel { Id = 1, GroupId = 1, LessionId = 1, TeacherId = 1 })).Callback((LectureEditModel model) => { });

            var LectureController = new LectureController(LectureServiceMock.Object, GroupServiceMock.Object, TeacherServiceMock.Object, LessionServiceMock.Object);

            var Result = await LectureController.Edit(new LectureEditModel { Id = 1, GroupId = 1, LessionId = 1, TeacherId = 1 });

            Assert.NotNull(Result);


        }

        [Fact]
        public async Task DeleteTest()
        {
            var LectureServiceMock = new Mock<ILectureService>();
            var GroupServiceMock = new Mock<IGroupService>();
            var TeacherServiceMock = new Mock<ITeacherService>();
            var LessionServiceMock = new Mock<ILessionService>();

            LectureServiceMock.Setup(repo => repo.Delete(1)).Callback((int Id) => { });

            var LectureController = new LectureController(LectureServiceMock.Object, GroupServiceMock.Object, TeacherServiceMock.Object, LessionServiceMock.Object);

            var Result = LectureController.Delete(1);

            Assert.NotNull(Result);
        }
        


        private List<LectureIndexModel> GetLectureIndexModels()
        {
            return new List<LectureIndexModel> {
                new LectureIndexModel{Id = 1, LessionName = "Математика-1" },
                new LectureIndexModel{Id = 2, LessionName = "Математика-2" },
                new LectureIndexModel{Id = 3, LessionName = "Математика-3" },
                new LectureIndexModel{Id = 4, LessionName = "Математика-4" },
                new LectureIndexModel{Id = 5, LessionName = "Математика-5" }
             };
        }


        private LectureDetailsModel GetDetailsModel(int? Id)
        {
            return new LectureDetailsModel {Id = 1, GroupId=1, GroupName = "Group", LessionId = 1, LessionName="Математика", TeacherId=1, TeacherName="Тичар"};
        }

        private SelectList GetTeacherSelectListItems()
        {
            var Teachers = new List<Teacher>()
            {
                new Teacher{ Id=1, Name="TeacherName1"},
                new Teacher{ Id=2, Name="TeacherName2"},
                new Teacher{ Id=3, Name="TeacherName3"},
                new Teacher{ Id=4, Name="TeacherName4"}
            };

            return new SelectList (Teachers ,"Id", "Name" );
        }

        private SelectList GetGroupSelectListItems()
        {
            var Groups = new List<Group>()
            {
                new Group{ Id = 1, Name ="Group1"},
                new Group{ Id = 1, Name ="Group2"},
                new Group{ Id = 1, Name ="Group3"},
                new Group{ Id = 1, Name ="Group4"}
            };

            return new SelectList(Groups, "Id", "Name");
        }

        private SelectList GetLessionSelectListItems()
        {
            var Lessions = new List<Lession>()
            {
                new Lession{Id = 1, Name="Lession1"},
                new Lession{Id = 2, Name="Lession2"},
                new Lession{Id = 3, Name="Lession3"},
                new Lession{Id = 4, Name="Lession4"}
            };

            return new SelectList(Lessions, "Id", "Name");
        }

        private LectureEditModel LectureGetEditModelMockMethod(int Id)
        {
            return new LectureEditModel { Id = 1, GroupId = 1, LessionId = 1, TeacherId = 1 };
        }

    }
}
