using Deadline9.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    public interface ILessionService
    {
        public void Delete(int Id);

        public void Edit(LessionEditModel model);

        public LessionEditModel GetEditModel(int Id);

        public void Create(LessionCreateModel model);

        public LessionDetailsModel GetDetailsModel(int Id);

        public List<LessionIndexModel> GetAll();

        public SelectList GetSelectListItems();

        public int Like(int Id);
    }
}
