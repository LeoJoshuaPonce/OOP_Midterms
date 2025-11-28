using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midterms
{
    public class SchoolAdmin : School
    {
        private static int studentId = 1;
        private static int membershipId = 1;
        private Membership membershipChecker;

        public static int GetNextStudentId()
        {
            return studentId++;
        }
        public static int GetNextMembershipId()
        {
            return membershipId++;
        }

        public SchoolAdmin()
        {
            membershipChecker = new Membership();
        }

        public void AddNewStudentToClub()
        {
            DisplayClubs();
            Console.Write("Enter Club ID to join: ");
            string clubInput = Console.ReadLine();
            if (!int.TryParse(clubInput, out int clubId))
            {
                Console.WriteLine("Invalid Club ID.");
                return;
            }

            Club targetClub = null;
            for (int i = 0; i < clubs.Count; i++)
            {
                if (clubs[i].Id == clubId)
                {
                    targetClub = clubs[i];
                    break;
                }
            }

            if (targetClub == null)
            {
                Console.WriteLine("Club not found.");
                return;
            }

            Console.Write("enter student first name: ");
            string studentFName = Console.ReadLine();
            Console.Write("enter student last name: ");
            string studentLName = Console.ReadLine();

            Console.Write("enter student age: ");
            string ageInput = Console.ReadLine();
            if (!int.TryParse(ageInput, out int studentAge))
            {
                Console.WriteLine("Invalid age.");
                return;
            }

            Console.Write("enter student grade level: ");
            string studentGrade = Console.ReadLine();
            Console.Write("enter student section: ");
            string studentSection = Console.ReadLine();

            Console.WriteLine($"Add student {studentFName} {studentLName} to {targetClub.Name}? Press Enter to confirm.");
            Console.ReadLine();

            Student addedStudent = new Student(GetNextStudentId(), studentFName, studentLName, studentAge, studentGrade, studentSection);
            students.Add(addedStudent);

            targetClub.Students.Add(addedStudent);
            addedStudent.Clubs.Add(targetClub);

            Membership newMembership = new Membership(GetNextMembershipId(), addedStudent, targetClub);
            membershipChecker.AddMembership(newMembership);

            Console.WriteLine($"Student {studentFName} {studentLName} added to {targetClub.Name}.");
        }

        public void AddExistingStudentToClub()
        {
            DisplayClubs();
            Console.Write("enter the club id to join: ");
            string clubInput = Console.ReadLine();
            if (!int.TryParse(clubInput, out int clubId))
            {
                Console.WriteLine("invalid club id.");
                return;
            }

            Club targetClub = null;
            for (int i = 0; i < clubs.Count; i++)
            {
                if (clubs[i].Id == clubId)
                {
                    targetClub = clubs[i];
                    break;
                }
            }

            if (targetClub == null)
            {
                Console.WriteLine("club not found.");
                return;
            }

            if (students == null || students.Count == 0)
            {
                Console.WriteLine("no students available to add.");
                return;
            }

            Console.WriteLine("existing students:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"ID: {students[i].Id} | Name: {students[i].FullName()}");
            }

            Console.Write("enter student id to add to the club: ");
            string studentInput = Console.ReadLine();
            if (!int.TryParse(studentInput, out int selectedStudentId))
            {
                Console.WriteLine("invalid student id.");
                return;
            }

            Student studentFound = null;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == selectedStudentId)
                {
                    studentFound = students[i];
                    break;
                }
            }

            if (studentFound == null)
            {
                Console.WriteLine("student not found.");
                return;
            }

            for (int i = 0; i < targetClub.Students.Count; i++)
            {
                if (targetClub.Students[i].Id == studentFound.Id)
                {
                    Console.WriteLine($"{studentFound.FullName()} is already a member of {targetClub.Name}.");
                    return;
                }
            }

            Console.WriteLine($"addd student {studentFound.FullName()} to {targetClub.Name}? press enter to confirm.");
            Console.ReadLine();

            targetClub.Students.Add(studentFound);
            studentFound.Clubs.Add(targetClub);

            Membership newMembership = new Membership(GetNextMembershipId(), studentFound, targetClub);
            membershipChecker.AddMembership(newMembership);

            Console.WriteLine($"student {studentFound.FirstName} {studentFound.LastName} added to {targetClub.Name}.");
        }

        public void RemoveStudentFromClub()
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{students[i].Id}: {students[i].FullName()} | {students[i].GradeSection()}");
            }

            Console.Write("Enter Student ID to remove from a club: ");
            string studentInput = Console.ReadLine();
            if (!int.TryParse(studentInput, out int studentId))
            {
                Console.WriteLine("Invalid Student ID.");
                return;
            }

            Student targetStudent = null;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == studentId)
                {
                    targetStudent = students[i];
                    break;
                }
            }

            if (targetStudent == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            List<Club> memberClubs = new List<Club>();
            for (int i = 0; i < clubs.Count; i++)
            {
                for (int j = 0; j < clubs[i].Students.Count; j++)
                {
                    if (clubs[i].Students[j].Id == targetStudent.Id)
                    {
                        memberClubs.Add(clubs[i]);
                        break;
                    }
                }
            }

            if (memberClubs.Count == 0)
            {
                Console.WriteLine("student is not a member of any clubs.");
                return;
            }

            Console.WriteLine("clubs the student is a member of:");
            for (int i = 0; i < memberClubs.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {memberClubs[i].Name} (ID: {memberClubs[i].Id})");
            }

            Console.Write("choose the club to remove the student from: ");
            string clubChoiceInput = Console.ReadLine();
            if (!int.TryParse(clubChoiceInput, out int clubChoice) || clubChoice < 1 || clubChoice > memberClubs.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            Club selectedClub = memberClubs[clubChoice - 1];

            Console.WriteLine($"remove {targetStudent.FullName()} from {selectedClub.Name}? press Enter to confirm.");
            Console.ReadLine();

            for (int i = 0; i < selectedClub.Students.Count; i++)
            {
                if (selectedClub.Students[i].Id == targetStudent.Id)
                {
                    selectedClub.Students.RemoveAt(i);
                    break;
                }
            }

            for (int i = 0; i < targetStudent.Clubs.Count; i++)
            {
                if (targetStudent.Clubs[i].Id == selectedClub.Id)
                {
                    targetStudent.Clubs.RemoveAt(i);
                    break;
                }
            }

            List<Membership> studentMemberships = membershipChecker.GetMembershipsForStudent(targetStudent.Id);
            for (int i = 0; i < studentMemberships.Count; i++)
            {
                if (studentMemberships[i].Club != null && studentMemberships[i].Club.Id == selectedClub.Id)
                {
                    studentMemberships[i].Status = false;
                    break;
                }
            }

            Console.WriteLine($"ttudent {targetStudent.FullName()} removed from {selectedClub.Name}.");
        }
        public void GenerateReport()
        {
            if (clubs == null || clubs.Count == 0)
            {
                Console.WriteLine("No clubs available to report.");
                return;
            }

            Console.WriteLine("club membership report:\n");

            for (int i = 0; i < clubs.Count; i++)
            {
                Club club = clubs[i];
                Console.WriteLine($"club: {club.Name} (id: {club.Id})");

                List<Membership> clubMemberships = membershipChecker.GetMembershipsForClub(club.Id);

                if (clubMemberships == null || clubMemberships.Count == 0)
                {
                    if (club.Students == null || club.Students.Count == 0)
                    {
                        Console.WriteLine("\tno members recorded.");
                    }
                    else
                    {
                        Console.WriteLine("\tcurrent members:");
                        for (int m = 0; m < club.Students.Count; m++)
                        {
                            var s = club.Students[m];
                            Console.WriteLine($"    {s.Id}: {s.FullName()}");
                        }
                    }
                }
                else
                {
                    int activeCount = 0;
                    Console.WriteLine(" \tmembership records:");
                    for (int m = 0; m < clubMemberships.Count; m++)
                    {
                        var mem = clubMemberships[m];
                        string status = mem.Status ? "active" : "inactive";
                        if (mem.Status) activeCount++;
                        Console.WriteLine($"\t{mem.Student.Id}: {mem.Student.FullName()} | status: {status} | joined: {mem.JoinDate.ToShortDateString()}");
                    }
                    Console.WriteLine($"\tactive memberships: {activeCount} / {clubMemberships.Count}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("end of report. press enter to continue...");
            Console.ReadLine();
        }
        public void MembershipHistory()
        {
            membershipChecker.ShowMembershipHistory();
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
                    "\n6: membership history\n7: generate report\n8: quit system");
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
                    RemoveStudentFromClub();
                    ClearDisplay();
                }
                else if (option == 5)
                {
                    ShowStudents();
                    ClearDisplay();
                }
                else if (option == 6)
                {
                    MembershipHistory();
                    ClearDisplay();
                }
                else if (option == 7)
                {
                    GenerateReport();
                }
                else if (option == 8)
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