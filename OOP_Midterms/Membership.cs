using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midterms
{
    public class Membership
    {
        public int MembershipID { get; set; }
        public Student Student;
        public Club Club;
        public bool Status { get; set; } = true;
        public DateTime JoinDate { get; set; } = DateTime.Now;

        public Membership(Student student, Club club)
        {
            Student = student;
            Club = club;
        }
    }
}
