using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB
{
    static class Menu
    {
        //Main Menu methods========================================================================
        /// <summary>
        /// Informs the user for the choices in the Main Menu
        /// </summary>
        static void Intro()
        {
            Console.WriteLine();
            Console.WriteLine("To view data from database press 1.");
            Console.WriteLine("To insert data in database press 2.");
            Console.WriteLine();
            Console.WriteLine("To terminate the app type \"EXIT\"");
            Console.WriteLine();

        }
        /// <summary>
        /// Enters the choice from "MainMenu()" method and enters to the selected choice
        /// </summary>
        /// <param name="input"></param>
        static void ChoiceSwitch(string input)
        {
            switch (input)
            {

                case "1":
                    {
                        ViewMenu();
                        break;
                    }
                case "2":
                    {
                        InputMenu();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid selection! Please try again");
                        break;
                    }
            }
        }
        /// <summary>
        /// Main menu for the project
        /// </summary>
        public static void MainMenu()
        {
            Intro();
            string selection = Console.ReadLine();
            while (selection.ToUpper() != "EXIT")
            {
                ChoiceSwitch(selection);
                Intro();
                selection = Console.ReadLine();
            }
        }
        //=========================================================================================
        /*
         * 
         * 
         * 
         */
        //View Menu methods========================================================================
        /// <summary>
        /// Menu to view organized the data from database
        /// </summary>
        static void ViewMenu()
        {
            ViewIntro();
            string selection = Console.ReadLine();
            while (selection.ToUpper() != "BACK")
            {
                ViewChoiceSwitch(selection);
                ViewIntro();
                selection = Console.ReadLine();
            }
        }
        /// <summary>
        /// Informs the user for the choices in the View Menu
        /// </summary>
        static void ViewIntro()
        {
            Console.WriteLine();
            Console.WriteLine("To view all courses press 1");
            Console.WriteLine("To view all trainers press 2");
            Console.WriteLine("To view all students press 3");
            Console.WriteLine("To view all assignments press 4");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("To view all the student per course press 5");
            Console.WriteLine("To view all the trainers per course press 6");
            Console.WriteLine("To view all the assignments per course press 7");
            Console.WriteLine("To view all the assignments per course per student press 8");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("To view the students that belong to more than one course press 9");
            Console.WriteLine();
            Console.WriteLine("To go to the Main menu type \"BACK\"");
            Console.WriteLine();

        }
        /// <summary>
        /// Enters the choice from "ViewMenu()" method and enters to the selected choice
        /// </summary>
        /// <param name="input"></param>
        static void ViewChoiceSwitch(string input)
        {
            switch (input)
            {

                case "1":
                    {
                        ReadDB.Courses();
                        break;
                    }
                case "2":
                    {
                        ReadDB.Trainers();
                        break;
                    }
                case "3":
                    {
                        ReadDB.Students();
                        break;
                    }
                case "4":
                    {
                        ReadDB.Assignments();
                        break;
                    }
                case "5":
                    {
                        ReadDB.StudentsPerCourse();
                        break;
                    }
                case "6":
                    {
                        ReadDB.TrainersPerCourse();
                        break;
                    }
                case "7":
                    {
                        ReadDB.AssignmentsPerCourse();
                        break;
                    }
                case "8":
                    {
                        ReadDB.AssignmentsPerCoursePerStudent();
                        break;
                    }
                case "9":
                    {
                        ReadDB.StudentsOver1Course();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid selection! Please try again");
                        break;
                    }
            }
        }
        //=========================================================================================
        /*
         * 
         * 
         * 
         */
        //Input Menu methods=======================================================================
        /// <summary>
        /// Menu to insert data to the database
        /// </summary>
        static void InputMenu()
        {
            InputIntro();
            string selection = Console.ReadLine();
            while (selection.ToUpper() != "BACK")
            {
                InputChoiceSwitch(selection);
                InputIntro();
                selection = Console.ReadLine();
            }
        }
        /// <summary>
        /// Informs the user for the choices in the Input Menu
        /// </summary>
        static void InputIntro()
        {
            Console.WriteLine();
            Console.WriteLine("To insert courses press 1");
            Console.WriteLine("To insert trainers press 2");
            Console.WriteLine("To insert students press 3");
            Console.WriteLine("To insert assignments press 4");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("To insert a student in a course press 5");
            Console.WriteLine("To insert a trainer in a course press 6");
            Console.WriteLine("To insert a assignments in a course and in a student press 7");
            Console.WriteLine();
            Console.WriteLine("To go to the Main menu type \"BACK\"");
            Console.WriteLine();

        }
        /// <summary>
        /// Enters the choice from "InputMenu()" method and enters to the selected choice
        /// </summary>
        /// <param name="input"></param>
        static void InputChoiceSwitch(string input)
        {
            switch (input)
            {

                case "1":
                    {
                        WriteDB.Course();
                        break;
                    }
                case "2":
                    {
                        WriteDB.Trainer();
                        break;
                    }
                case "3":
                    {
                        WriteDB.Student();
                        break;
                    }
                case "4":
                    {
                        WriteDB.Assignment();
                        break;
                    }
                case "5":
                    {
                        WriteDB.StudentsPerCourse();
                        break;
                    }
                case "6":
                    {
                        WriteDB.TrainersPerCourse();
                        break;
                    }
                case "7":
                    {
                        WriteDB.AssignmentsPerCoursePerStudent();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid selection! Please try again");
                        break;
                    }
            }
        }
        //=========================================================================================
    }
}
