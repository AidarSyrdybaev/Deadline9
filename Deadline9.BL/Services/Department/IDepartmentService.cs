using Deadline9.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    public interface IDepartmentService
    {
        public void Delete(int Id);

        public void Edit(DepartmentModel model);

        public void Create(DepartmentCreateModel model);

        public void Details(int Id);

        public List<DepartmentModel> GetAll();

        public DepartmentModel GetDepartmentModel(int Id);

        public SelectList GetDepartmentsSelectListItems();
    }
}
