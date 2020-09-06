using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Entities
{
    public class Role: IdentityRole<int>, IEntity
    {
    }
}
