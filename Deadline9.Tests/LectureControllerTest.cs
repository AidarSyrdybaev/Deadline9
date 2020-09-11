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

    }
}
