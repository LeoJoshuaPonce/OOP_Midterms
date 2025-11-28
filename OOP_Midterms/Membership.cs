using System;
using System.Collections.Generic;
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

        private List<Membership> memberships;

        public Membership(int id, Student student, Club club)
        {
            MembershipID = id;
            Student = student;
            Club = club;
        }

        public Membership()
        {
            memberships = new List<Membership>();
        }

        public void ShowMembershipHistory()
        {
            if (memberships == null || memberships.Count == 0)
            {
                Console.WriteLine("No membership history available.");
                return;
            }

            for (int i = 0; i < memberships.Count; i++)
            {
                var m = memberships[i];
                string statusText = m.Status ? "Active" : "Inactive";
                Console.WriteLine($"Membership ID: {m.MembershipID}, Student: {m.Student.FullName()}, Club: {m.Club.Name}, Status: {statusText}, Join Date: {m.JoinDate.ToShortDateString()}");
            }
        }

        public Membership AddMembership(Membership membership)
        {
            if (membership == null)
            {
                return null;
            }

            if (memberships == null)
            {
                memberships = new List<Membership>();
            }

            memberships.Add(membership);
            return membership;
        }

        public bool RemoveMembershipById(int membershipId)
        {
            if (memberships == null)
            {
                return false;
            }

            for (int i = 0; i < memberships.Count; i++)
            {
                if (memberships[i].MembershipID == membershipId)
                {
                    memberships.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public Membership FindMembershipById(int membershipId)
        {
            if (memberships == null)
            {
                return null;
            }

            for (int i = 0; i < memberships.Count; i++)
            {
                if (memberships[i].MembershipID == membershipId)
                {
                    return memberships[i];
                }
            }
            return null;
        }

        public List<Membership> GetMembershipsForStudent(int studentId)
        {
            List<Membership> result = new List<Membership>();
            if (memberships == null)
            {
                return result;
            }

            for (int i = 0; i < memberships.Count; i++)
            {
                var m = memberships[i];
                if (m.Student != null && m.Student.Id == studentId)
                {
                    result.Add(m);
                }
            }
            return result;
        }

        public List<Membership> GetMembershipsForClub(int clubId)
        {
            List<Membership> result = new List<Membership>();
            if (memberships == null)
            {
                return result;
            }

            for (int i = 0; i < memberships.Count; i++)
            {
                var m = memberships[i];
                if (m.Club != null && m.Club.Id == clubId)
                {
                    result.Add(m);
                }
            }
            return result;
        }
    }
}
