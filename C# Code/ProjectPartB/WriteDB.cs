using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectPartB
{
    class WriteDB
    {
        /// <summary>
        /// String with the properties to connect to the database
        /// </summary>
        static string connectionString = Properties.Settings.Default.connect;
        // Methods to insert local data in the database table ================
        /// <summary>
        /// Inserts a course in the database
        /// </summary>
        public static void Course() 
        {
            try
            {
                Console.WriteLine("Enter the properties of the course:");
                Console.Write("\tTitle: ");
                string Title = Console.ReadLine();
                Console.Write("\tStream: ");
                string Stream = Console.ReadLine();
                Console.Write("\tType: ");
                string Type = Console.ReadLine();
                Console.Write("\tStart date (Must be written like \"d / M / yyyy\"): ");
                DateTime StartDate = DateInput();
                Console.Write("\tEnd date (Must be written like \"d / M / yyyy\"): ");
                DateTime EndDate = ExpireInput(StartDate);

                string insertqr = "Insert into Course (Title, Stream, Type, StartDate, EndDate) values (@Title, @Stream, @Type, @StartDate, @EndDate)";
                

                SqlConnection dbcon = new SqlConnection(connectionString);
                using (dbcon)
                {
                    dbcon.Open();
                    var command = new SqlCommand(insertqr, dbcon);

                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Stream", Stream);
                    command.Parameters.AddWithValue("@Type", Type);
                    command.Parameters.AddWithValue("@StartDate", StartDate);
                    command.Parameters.AddWithValue("@EndDate", EndDate);

                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Course inserted successfully!");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Could not insert course...");
                Console.WriteLine("Error type: "+ e.Message);
            }
            finally { }
        }
        /// <summary>
        /// Inserts a trainer in the database
        /// </summary>
        public static void Trainer() 
        {
            try
            {
                Console.WriteLine("Enter the properties of the trainer:");
                Console.Write("\tFirst Name: ");
                string FirstName = NameInput();
                Console.Write("\tLast Name: ");
                string LastName = NameInput();
                Console.Write("\tSubject: ");
                string Subject = Console.ReadLine();
                

                string insertqr = "Insert into Trainer (FirstName, LastName, Subject) " +
                                    "values (@FirstName, @LastName, @Subject)";


                SqlConnection dbcon = new SqlConnection(connectionString);
                using (dbcon)
                {
                    dbcon.Open();
                    var command = new SqlCommand(insertqr, dbcon);

                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Subject", Subject);
                    

                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Trainer inserted successfully!");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Could not insert trainer...");
                Console.WriteLine("Error type: " + e.Message);
            }
            finally { }
        }
        /// <summary>
        /// Inserts a student in the database
        /// </summary>
        public static void Student() 
        {
            try
            {
                Console.WriteLine("Enter the properties of the student:");
                Console.Write("\tName: ");
                string FirstName = NameInput();
                Console.Write("\tSurname: ");
                string LastName = NameInput();
                Console.Write("\tDate of birt (Must be written like \"dd / MM / yyyy\"): ");
                DateTime DateOfBirth = BirthInput();
                Console.Write("\tTuition Fees: ");
                float TuitionFees = FloatInput();

                string insertqr = "Insert into Student (FirstName, LastName,DateOfBirth,TuitionFees ) " +
                                    "values (@FirstName, @LastName, @DateOfBirth, @TuitionFees)";


                SqlConnection dbcon = new SqlConnection(connectionString);
                using (dbcon)
                {
                    dbcon.Open();
                    var command = new SqlCommand(insertqr, dbcon);

                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@TuitionFees", TuitionFees);

                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Student inserted successfully!");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Could not insert student...");
                Console.WriteLine("Error type: " + e.Message);
            }
            finally { }
        }
        /// <summary>
        /// Inserts an assignment in the database
        /// </summary>
        public static void Assignment() 
        {
            try
            {
                Console.WriteLine("Enter the properties of the assignment:");
                Console.Write("\tTitle: ");
                string Title = Console.ReadLine();
                Console.Write("\tDescription: ");
                string Description = Console.ReadLine();
                Console.Write("\tSubmition date (Must be written like \"d / M / yyyy HH:mm\"): ");
                DateTime SubDateTime = DateTimeInput();

                string insertqr = "Insert into Assignment (Title, Description, SubDateTime) " +
                                    "values (@Title, @Description, @SubDateTime)";


                SqlConnection dbcon = new SqlConnection(connectionString);
                using (dbcon)
                {
                    dbcon.Open();
                    var command = new SqlCommand(insertqr, dbcon);

                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@SubDateTime", SubDateTime);
                    

                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Assignment inserted successfully!");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Could not insert assignment...");
                Console.WriteLine("Error type: " + e.Message);
            }
            finally { }
        }
        //=====================================================================
        /*
         * 
         * 
         * 
         */
        // Methods to combine data from database ==============================
        /// <summary>
        /// Inserts students in a Course
        /// </summary>
        public static void StudentsPerCourse() 
        {
            // Course selection
            ReadDB.Courses();
            Console.Write("Choose the id of the course: ");
            int courseSelection = IntInput();

            // Student selection
            ReadDB.Students();
            Console.Write("Choose the id of the student: ");
            int studentSelection = IntInput();

            string insertqr = "Insert into Courses_Students (CourseID, StudentID ) " +
                                    "values (@CourseID, @StudentID)";

     
            try 
            {
                using (SqlConnection dbcon = new SqlConnection(connectionString))
                {
                    dbcon.Open();
                    var command = new SqlCommand(insertqr, dbcon);

                    command.Parameters.AddWithValue("@CourseID", courseSelection);
                    command.Parameters.AddWithValue("@StudentID", studentSelection);


                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Student related successfully to the course!");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Type: "+e.Message);
            }
            finally { }
        }
        /// <summary>
        /// Inserts trainers in a Course
        /// </summary>
        public static void TrainersPerCourse() 
        {
            // Course selection
            ReadDB.Courses();
            Console.Write("Choose the id of the course: ");
            int courseSelection = IntInput();

            // Trainer selection
            ReadDB.Trainers();
            Console.Write("Choose the id of the trainer: ");
            int trainerSelection = IntInput();

            string insertqr = "Insert into Course_Trainer (CourseID, TrainerID ) " +
                                    "values (@CourseID, @TrainerID)";


            try
            {
                using (SqlConnection dbcon = new SqlConnection(connectionString))
                {
                    dbcon.Open();
                    var command = new SqlCommand(insertqr, dbcon);

                    command.Parameters.AddWithValue("@CourseID", courseSelection);
                    command.Parameters.AddWithValue("@TrainerID", trainerSelection);


                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Trainer related successfully to the course!");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Type: " + e.Message);
            }
            finally { }
        }
        /// <summary>
        /// Inserts assignments in a Course per Student
        /// </summary>
        public static void AssignmentsPerCoursePerStudent() 
        {
            // Course selection
            ReadDB.Courses();
            Console.Write("Choose the id of the course: ");
            int courseSelection = IntInput();

            // Student selection
            ReadDB.Students();
            Console.Write("Choose the id of the student: ");
            int studentSelection = IntInput();

            // Assignment selection
            ReadDB.Assignments();
            Console.Write("Choose the id of the assignment: ");
            int assignmentSelection = IntInput();

            Console.WriteLine("Is the assignment submitted?");
            if (BoolInput())
            {

                // Assignment selection
                Console.Write("Insert the oral mark (if exists): ");
                int? OralMark = MarkInput();

                // Assignment selection                
                Console.Write("Insert the total mark (if exists): ");
                int? TotalMark = MarkInput();

                string insertqr = "Insert into AssignmentPerCoursePerStudent (StudentID, CourseID, AssignmentID, Submited, OralMark, TotalMark) " +
                                    "values (@StudentID, @CourseID, @AssignmentID, @Submited, @OralMark, @TotalMark)";

                try
                {
                    using (SqlConnection dbcon = new SqlConnection(connectionString))
                    {
                        dbcon.Open();
                        var command = new SqlCommand(insertqr, dbcon);

                        command.Parameters.AddWithValue("@CourseID", courseSelection);
                        command.Parameters.AddWithValue("@StudentID", studentSelection);
                        command.Parameters.AddWithValue("@AssignmentID", assignmentSelection);
                        command.Parameters.AddWithValue("@Submited", true);
                        command.Parameters.AddWithValue("@OralMark", OralMark);
                        command.Parameters.AddWithValue("@TotalMark", TotalMark);


                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("Assignment related successfully to the course and to the student!");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Type: " + e.Message);
                }
                finally { }
            }
            else
            {
                string insertqr = "Insert into AssignmentPerCoursePerStudent (StudentID, CourseID, AssignmentID, Submited) " +
                                        "values (@StudentID, @CourseID, @AssignmentID, @Submited)";
                try
                {
                    using (SqlConnection dbcon = new SqlConnection(connectionString))
                    {
                        dbcon.Open();                        
                        var command = new SqlCommand(insertqr, dbcon);

                        command.Parameters.AddWithValue("@CourseID", courseSelection);
                        command.Parameters.AddWithValue("@StudentID", studentSelection);
                        command.Parameters.AddWithValue("@AssignmentID", assignmentSelection);
                        command.Parameters.AddWithValue("@Submited", false);


                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("Assignment related successfully to the course and to the student!");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Type: " + e.Message);
                }
                finally { }
            }

            
            

            
        }
        //=====================================================================
        

        //Validators ==========================================================
        /// <summary>
        /// Value input for name or surname purposes
        /// </summary>
        /// <returns></returns>
        static string NameInput()
        {
            bool check;
            string input = Console.ReadLine();

            do
            {
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Name cannot be null!");
                    Console.Write("Put a valid name: ");
                    Console.ReadLine();
                    check = true;
                }
                else if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Name cannot have space!");
                    Console.Write("Put a valid name: ");
                    Console.ReadLine();
                    check = true;
                }
                else if (input.Length < 3)
                {
                    Console.WriteLine("Name must have less than 3 words!");
                    Console.Write("Put a valid name: ");
                    input = Console.ReadLine();
                    check = true;
                }
                else if (input.Length > 20)
                {
                    Console.WriteLine("Name must have more than 25 words!");
                    Console.Write("Put a valid name: ");
                    input = Console.ReadLine();
                    check = true;
                }
                else
                {
                    check = false;
                }
            }
            while (check);
            return input;
        }
        /// <summary>
        /// Value input for integer purposes
        /// </summary>
        /// <returns></returns>
        static int IntInput()
        {
            string input = Console.ReadLine();
            int output;

            while (!int.TryParse(input, out output))
            {

                try
                {
                    output = Convert.ToInt32(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("You inserted an invalid number!");


                }
                catch (OverflowException)
                {
                    Console.WriteLine("You inserted a very long number!");
                }
                Console.Write("Enter a valid integer number: ");
                input = Console.ReadLine();
            }
            return output;
        }
        /// <summary>
        /// Value input for marking purposes (0-100)
        /// </summary>
        /// <returns></returns>
        static int? MarkInput()
        {
            string input = Console.ReadLine();
            int output = -1;

            if (input == string.Empty) { return null; }

            do
            {

                try
                {
                    output = Convert.ToInt32(input);
                    if (output < 0 || output > 100)
                    {
                        Console.Write("Enter a valid mark (from 0 to 100): ");
                        input = Console.ReadLine();
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("You inserted an invalid mark!");


                }
                catch (OverflowException)
                {
                    Console.WriteLine("You inserted a very long number!");
                }

            }
            while (output < 0 || output > 100);

            return output;
        }
        /// <summary>
        /// Value input for float purposes
        /// </summary>
        /// <returns></returns>
        static float FloatInput()
        {
            string input = Console.ReadLine();
            float output;
            while (!float.TryParse(input, out output))
            {
                Console.WriteLine("You have entered an invalid number!");
                Console.Write("Enter a valid number: ");
                input = Console.ReadLine();
            }
            return output;

        }
        /// <summary>
        /// Value input for date purposes
        /// </summary>
        /// <returns></returns>
        static DateTime DateInput()
        {
            string date = Console.ReadLine();
            DateTime correctDate;
            while (!DateTime.TryParseExact(date, "d/M/yyyy", null, System.Globalization.DateTimeStyles.None, out correctDate))
            {
                Console.WriteLine("Invalid data input!");
                Console.Write("The date must be written like \"d / M / yyyy\"): ");
                date = Console.ReadLine();
            }
            return correctDate;
        }
        /// <summary>
        /// Value input for date and time purposes
        /// </summary>
        /// <returns></returns>
        static DateTime DateTimeInput()
        {
            string date = Console.ReadLine();
            DateTime correctDate;
            while (!DateTime.TryParseExact(date, "d/M/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out correctDate))
            {
                Console.WriteLine("Invalid data input!");
                Console.Write("The date must be written like \"d / M / yyyy HH:mm\"");
                date = Console.ReadLine();
            }
            return correctDate;
        }
        /// <summary>
        /// Value input to check valid expiration date. (Requires start date)
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        static DateTime ExpireInput(DateTime startDate)
        {
            DateTime input = DateInput();
            while (input < startDate)
            {
                Console.WriteLine("The End date cannot be before the Start date!!");
                Console.Write("Please insert a valid date: ");
                input = DateInput();
            }
            return input;
        }
        /// <summary>
        /// Value input to check valid date of birth
        /// </summary>
        /// <returns></returns>
        static DateTime BirthInput()
        {
            DateTime input = DateInput();
            while (input >= DateTime.Now)
            {
                Console.WriteLine("The birth date cannot be in future!!");
                Console.Write("Please insert a valid date: ");
                input = BirthInput();
            }
            return input;
        }
        /// <summary>
        /// Insert yes or no and returns true or false
        /// </summary>
        /// <returns></returns>
        static bool BoolInput()
        {
            Console.Write("Type \"Yes/No\" for your choice: ");
            string input = Console.ReadLine();

            do
            {
                if (input.ToUpper() == "YES") { return true; }
                else if (input.ToUpper() == "NO") { return false; }

                Console.WriteLine("Invalid choice inserted!");
                Console.Write("Type \"Yes/No\" for your choice: ");
                input = Console.ReadLine();
            }
            while (true);
        }
    }
}
