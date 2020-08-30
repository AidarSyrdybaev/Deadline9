using Deadline9.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    public interface IGroupService
    {
        public void Delete(int Id);

        public void Edit(GroupEditModel model);

        public GroupEditModel GetEditModel(int Id);

        public void Create(GroupCreateModel model);

        public void Details(int Id);

        public List<GroupIndexModel> GetAll();

        public SelectList GetSelectListItems();
    }
}
