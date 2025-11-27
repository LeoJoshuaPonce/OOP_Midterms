//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OOP_Midterms
//{
//    public class ViewModel
//    {
//        SchoolAdmin admin;
//        public ViewModel()
//        {
//            admin = new SchoolAdmin();
//        }

//        public void Run()
//        {
//            while (true)
//            {
//                try
//                {
//                    Console.WriteLine("1 - Choose Club\n2 - Display Clubs\n3 - quit");
//                    int choice = int.Parse(Console.ReadLine());

//                    if (choice == 1)
//                    {
//                        admin.ChooseClub();
//                        Clear();
//                    }
//                    else if (choice == 2)
//                    {
//                        admin.DisplayClubs();
//                        Clear();
//                    }
//                    else if (choice == 3)
//                    {
//                        Console.WriteLine("Quitting the system.");
//                        Console.ReadLine();
//                        break;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"An error occurred: {ex.Message}");
//                }
//            }
//        }
//        private void Clear()
//        {
//            Console.WriteLine("Press Enter to continue...");
//            Console.ReadLine();
//            Console.Clear();
//        }
//    }
//}
