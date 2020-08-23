using Deadline9.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    public interface ISpecialtyService
    {
        public void Delete(int Id);

        public void Edit(SpecialtyEditModel model);

        public SpecialtyEditModel GetEditModel(int Id);

        public void Create(SpecialtyCreateModel model);

        public void Details(int Id);

        public List<SpecialtyIndexModel> GetAll();

        public SelectList GetSelectListItems();
    }
}
