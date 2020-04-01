using Plant.Model;
using System;
using System.Collections.Generic;

namespace Plant.Services
{
    /// <summary>
    /// Student service interface
    /// </summary>
    public partial interface IStudentService
    {
        /// <summary>
        /// Gets an employee by employee identifier
        /// </summary>
        /// <param name="email">Student identifier</param>
        /// <returns>Student</returns>

        Student GetStudentByID(int id);
        IList<Student> GetStudentsList();
        /// <summary>
        /// Marks employee as deleted 
        /// </summary>
        /// <param name="employee">Student</param>
        void DeleteStudent(Student employee);

       

        /// <summary>
        /// Inserts an employee
        /// </summary>
        /// <param name="employee">Student</param>
        void InsertStudent(Student employee);

        /// <summary>
        /// Updates the employee
        /// </summary>
        /// <param name="employee">Student</param>
        void UpdateStudent(Student employee);



    }
}