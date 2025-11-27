using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midterms
{
    public class SchoolAdmin : School
    {
        private static int studentId = 1;
        public static int GetNextStudentId()
        {
            return studentId++;
        }
        public SchoolAdmin()
        {
            Student students = new Student();
        }

        public void AddNewStudentToClub()
        {
            DisplayClubs();
            Console.Write("Enter Club ID to join:");
            int clubId = int.Parse(Console.ReadLine());

            for (int i = 0; i < clubs.Count; i++)
            {
                if (clubId == clubs[i].Id)
                {
                    var club = clubs[i];
                    Console.Write("enter student first name: ");
                    string studentFName = Console.ReadLine();
                    Console.Write("enter student last name: ");
                    string studentLName = Console.ReadLine();
                    Console.Write("enter student age: ");
                    int studentAge = int.Parse(Console.ReadLine());
                    Console.Write("enter student grade level: ");
                    string studentGrade = Console.ReadLine();
                    Console.Write("enter student section: ");
                    string studentSection = Console.ReadLine();

                    Student addedStudent = new Student(GetNextStudentId(), studentFName, studentLName, studentAge, studentGrade, studentSection);
                    students.Add(addedStudent);

                    Console.WriteLine($"Add student to {club.Name}?");
                    Console.ReadLine();
                    clubs[i].Students.Add(addedStudent);
                    Console.WriteLine($"Student {studentFName} {studentLName} added to {clubs[i].Name}.");
                    break;
                }
            }
        }
        public void AddExistingStudentToClub()
        {
            Student existingStudent = new Student();
            DisplayClubs();
            Console.Write("Enter Club ID to join:");
            int clubId = int.Parse(Console.ReadLine());

            for (int i = 0; i < clubs.Count; i++)
            {
                if (clubId == clubs[i].Id)
                {
                    var club = clubs[i];
                    existingStudent.DisplayStudents();
                    Console.Write("Enter Student ID to add to the club: ");
                    int studentId = int.Parse(Console.ReadLine());

                    existingStudent.FindStudent(studentId);
                    if (existingStudent != null)
                    {
                        Console.WriteLine($"Add student to {club.Name}?");
                        Console.ReadLine();
                        clubs[i].Students.Add(existingStudent);
                        Console.WriteLine($"Student {existingStudent.FirstName} {existingStudent.LastName} added to {clubs[i].Name}.");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;
                }
            }
        }
        private Student AddStudent(int id, string firstname, string lastname, int age, string gradelevel, string section)
        {
            Student newStudent = new Student(id, firstname, lastname, age, gradelevel, section);
            students.Add(newStudent);
            return newStudent;
        }

        private void ClearDisplay()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        public void GetOption()
        {
            while (true)
            {
                Console.WriteLine("1: display clubs\n2: add new student to a club\n3: add existing student to a club" +
                    "\n4: remove student from a club\n5: show students" +
                    "\n7: membership history\n8: generate report\n9: quit system");
                Console.Write("please select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    DisplayClubs();
                    ClearDisplay();
                }
                else if (option == 2)
                {
                    AddNewStudentToClub();
                    ClearDisplay();
                }
                else if (option == 3)
                {
                    AddExistingStudentToClub();
                    ClearDisplay();
                }
                else if (option == 4)
                {
                    //RemoveStudentFromClub();
                }
                else if (option == 5)
                {
                    ShowStudents();
                    ClearDisplay();
                }
                else if (option == 6)
                {
                    //MembershipHistory();
                }
                else if (option == 7)
                {
                    Console.WriteLine("Quitting the system.");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    ClearDisplay();
                    continue;
                }
            }
        }
    }
}
