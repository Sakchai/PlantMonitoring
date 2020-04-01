using System;
using LinqToDB.Mapping;

namespace Plant.Model
{

    [Table("STUDENT")]
    public class Student : BaseEntity
    {
        [Column("STUID"), PrimaryKey, Identity]
        public int Id { get; set; }
        [Column("FIRSTNAME", Length = 40), Nullable]
        public string FirstName { get; set; }
        [Column("SURNAME", Length = 40), Nullable]
        public string Surname { get; set; }
        [Column("AGE")]
        public int? Age { get; set; }
        [Column("SUBJECTSPASSED")]
        public int? SubjectsPassed { get; set; }
        [Column("GENDER", Length = 1), Nullable]
        public string Gender { get; set; }
    }

}
