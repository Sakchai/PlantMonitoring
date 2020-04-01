using System;
using System.Collections.Generic;
using System.Linq;
using Plant.Model;

namespace Plant.Services
{
    /// <summary>
    /// Student service
    /// </summary>
    public partial class StudentService : IStudentService
    {
        #region Fields


        private readonly IRepository<Student> _studentRepository;

        #endregion

        #region Ctor

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        #endregion

        #region Methods


      
        /// <summary>
        /// Marks student as deleted 
        /// </summary>
        /// <param name="student">Student</param>
        public virtual void DeleteStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            

        }

        /// <summary>
        /// Inserts an student
        /// </summary>
        /// <param name="student">Student</param>
        public virtual void InsertStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            _studentRepository.Insert(student);

        }

        /// <summary>
        /// Updates the student
        /// </summary>
        /// <param name="student">Student</param>
        public virtual void UpdateStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            _studentRepository.Update(student);

        }

        public Student GetStudentByID(int id)
        {
            if (id == 0)
                return null;

            return _studentRepository.GetById(id);

        }



        public IList<Student> GetStudentsList()
        {
            var query = _studentRepository.Table;
            return query.ToList();
        }



        #endregion
    }
}