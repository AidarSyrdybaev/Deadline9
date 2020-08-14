using DeadLine9.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Context
{
    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        private readonly DbContextOptions _options;

        public ApplicationDbContextFactory(DbContextOptions dbContextOptions)
        {
            if (dbContextOptions == null)
                throw new ArgumentNullException(nameof(dbContextOptions));
            _options = dbContextOptions;
        }
        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext(_options);
        }
    }
}
