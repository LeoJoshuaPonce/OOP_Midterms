using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midterms
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ViewModel vm = new ViewModel();
            //vm.Run();
            School school = new School();
            SchoolAdmin schoolAdmin = new SchoolAdmin();

            Console.WriteLine("Welcome to the club membership tracking system!");



            schoolAdmin.GetOption();


        }
    }
}
