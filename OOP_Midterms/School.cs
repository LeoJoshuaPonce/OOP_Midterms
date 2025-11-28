using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midterms
{
    public class School
    {
        public List<Club> clubs;
        public List<Student> students;
        private string memberListString = "";
        public School()
        {
            clubs = new List<Club>
            {
                new Club(1, "Science Club", DateTime.Today.AddHours(15), DateTime.Today.AddHours(16).AddMinutes(30),
                new List<string>(){"Monday", "Tuesday"}),
                new Club(2, "Chess Club",   DateTime.Today.AddHours(16), DateTime.Today.AddHours(17),
                new List<string>(){"Monday", "Friday"}),
                new Club(3, "Drama Club",   DateTime.Today.AddHours(14), DateTime.Today.AddHours(15).AddMinutes(30),
                new List<string>(){"Monday", "Thursday"}),
                new Club(4, "Math Club",    DateTime.Today.AddHours(15).AddMinutes(30), DateTime.Today.AddHours(16).AddMinutes(30),
                new List<string>(){"Monday", "Wednesday"}),
                new Club(5, "Art Club",     DateTime.Today.AddHours(13), DateTime.Today.AddHours(14).AddMinutes(30),
                new List<string>(){"Monday", "Tuesday"})
            };


            students = new List<Student>();
        }
        public void DisplayClubs()
        {
            Console.WriteLine("Clubs:");
            foreach (var club in clubs)
            {
                List<string> students = new List<string>();
                foreach (var student in club.Students)
                {
                    students.Add(student.FullName());
                }
                memberListString = string.Join(", ", students);
                Console.WriteLine($"ID: {club.Id}, Name: {club.Name}, Schedule: {club.Schedule()} - {string.Join(", ", club.Days)}, Member/s: {memberListString}");
            }
        }
        public void DisplayClubs(int id)
        {
            bool foundAnyClub = false;
            foreach (var club in clubs)
            {
                foreach (var student in club.Students)
                {
                    if (student.Id == id)
                    {
                        Console.WriteLine($"{club.Name}\n");
                        foundAnyClub = true;
                        break;
                    }
                }
            }
            if (!foundAnyClub)
            {
                Console.WriteLine($"No club joined for {students[id].FullName()}");
            }
        }
        public void ShowStudents()
        {
            foreach (Student student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.FullName()}, Age: {student.Age}, Grade&Section: {student.GradeSection()}, Section: {student.Section}");
            }
            Console.Write("Choose a student: ");
            int studentOption = int.Parse(Console.ReadLine());

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == studentOption)
                {
                    Console.WriteLine($"Student: {students[i].FullName()}\nGrade Level: {students[i].GradeLevel}\nSection: {students[i].Section}\nClubs:");
                    DisplayClubs(studentOption);
                    break;
                }
            }
        }
        public Student FindStudent()
        {
            foreach (var student in students)
            {
                return student;
            }
            return null;
        }
        public Student FindStudent(int id)
        {
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }
    }
}
