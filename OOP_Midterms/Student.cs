using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midterms
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string GradeLevel { get; set; }
        public string Section { get; set; }
        public List<Club> Clubs = new List<Club>();
        public Student(int id, string firstname, string lastname, int age, string gradelevel, string section)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            GradeLevel = gradelevel;
            Section = section;
        }
        public string GradeSection()
        {
            return $"{GradeLevel}-{Section}";
        }
        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
