using DeadLine9.DAL.Repositories;
using DeadLine9.DAL.Repositories.Contracts;
using System;

namespace DeadLine9.DAL.Context
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;

        private bool _disposed;
        public IDepartmentRepository Departments { get; }
        public ITeacherRepository Teachers { get; }
        public IStudentRepository Students { get; }
        public ILectureRepository Lectures { get; }
        public ILessionRepository Lessions { get; }
        public ISpecialityRepository Specialities { get; }
        public IGroupRepository Groups { get; }
        public IPointRepository Points { get; }
       

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Departments = new DepartmentRepository(context);
            Teachers = new TeacherRepository(context);
            Lectures = new LectureRepository(context);
            Lessions = new LessionRepository(context);
            Students = new StudentRepository(context);
            Specialities = new SpecialityRepository(context);
            Groups = new GroupRepository(context);
            Points = new PointRepository(context);
        }

        #region Disposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _context.Dispose();

            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}