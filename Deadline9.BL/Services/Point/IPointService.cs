using Deadline9.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    public interface IPointService
    {
        public void Edit(PointEditModel model);
        public void Delete(int Id);

        public PointEditModel GetEditModel(int Id);

        public void Create(PointCreateModel model);

        public PointDetailsModel GetDetailsModel(int Id);

        public List<PointIndexModel> GetAll();

        public SelectList GetSelectListItems();

    }
}
