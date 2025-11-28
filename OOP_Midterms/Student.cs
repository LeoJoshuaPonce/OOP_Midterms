using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midterms
{
    public class Student : School
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
        public bool IsExistingInClub(int clubId)
        {
            foreach (var club in Clubs)
            {
                if (club.Id == clubId)
                {
                    return true;
                }
            }
            return false;
        }

        //public Student DisplayStudents()
        //{
        //    foreach (Student student in students)
        //    {
        //        Console.WriteLine($"ID: {student.Id}, Name: {student.FullName()}, Age: {student.Age}, Grade: {student.GradeSection()}, Section: {student.Section}");
        //    }
        //    return this;
        //}
        //public bool IsExisting(int id)
        //{
        //    foreach (var student in students)
        //    {
        //        if (student.Id == id)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
