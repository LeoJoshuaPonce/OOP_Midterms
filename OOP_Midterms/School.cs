using System;
using System.Collections.Generic;

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
            Student student = FindStudent(id);
            if (student == null)
            {
                Console.WriteLine("student not found.");
                return;
            }

            bool foundAnyClub = false;
            for (int i = 0; i < clubs.Count; i++)
            {
                for (int j = 0; j < clubs[i].Students.Count; j++)
                {
                    if (clubs[i].Students[j].Id == id)
                    {
                        Console.WriteLine(clubs[i].Name + "\n");
                        foundAnyClub = true;
                        break;
                    }
                }
            }

            if (!foundAnyClub)
            {
                Console.WriteLine($"no club joined for {student.FullName()}");
            }
        }
        public void ShowStudents()
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("no students available.");
                return;
            }

            for (int i = 0; i < students.Count; i++)
            {
                var student = students[i];
                Console.WriteLine($"ID: {student.Id}, Name: {student.FullName()}, Age: {student.Age}, Grade&Section: {student.GradeSection()}, Section: {student.Section}");
            }

            Console.Write("Choose a student: ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("student selection is required.");
                return;
            }

            if (!int.TryParse(input, out int studentOption))
            {
                Console.WriteLine("Invalid student id.");
                return;
            }

            Student found = FindStudent(studentOption);
            if (found == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"student: {found.FullName()}\ngrade level: {found.GradeLevel}\nsection: {found.Section}\nclubs:");
            DisplayClubs(studentOption);
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
