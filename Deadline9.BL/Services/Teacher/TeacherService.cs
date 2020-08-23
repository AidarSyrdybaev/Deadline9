using DeadLine9.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.BL.Services
{
    public class TeacherService: ITeacherService
    {   
        private IUnitOfWorkFactory _UnitOfWorkFactory { get; }
        public TeacherService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _UnitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
