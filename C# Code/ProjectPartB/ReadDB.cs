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
    public static class ReadDB 
    {
        /// <summary>
        /// String with the properties to connect to the database
        /// </summary>
        static string connectionString = Properties.Settings.Default.connect;
        // Methods to view data from tables ==================================
        /// <summary>
        /// Shows all courses from the database
        /// </summary>
        public static void Courses() 
        {
            try
            {
                SqlConnection dbcon = new SqlConnection(connectionString);

                using (dbcon)
                {
                    dbcon.Open();
                    var cmd = new SqlCommand("select * from Course", dbcon);
                    var reader = cmd.ExecuteReader();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" __________ _______ ________ __________ ___________ ___________");
                    Console.WriteLine("| CourseID | Title | Stream |   Type   | StartDate |  EndDate  |");
                    Console.WriteLine(" __________ _______ ________ __________ ___________ ___________");

                    while (reader.Read())
                    {
                        var cid = reader["ID"];
                        var Title = reader["Title"];
                        var Stream = reader["Stream"];
                        var Type = reader["Type"];
                        var StartDate = Convert.ToDateTime(reader["StartDate"]).ToString("d/M/yyyy");
                        var EndDate = Convert.ToDateTime(reader["EndDate"]).ToString("d/M/yyyy");

                        
                        Console.WriteLine("|{0,10}|{1,7}|{2,8}|{3,10}|{4,11}|{5,11}|"
                            , cid, Title, Stream, Type, StartDate, EndDate);

                    }
                    
                    Console.WriteLine(" __________ _______ ________ __________ ___________ ___________");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally { }

        }
        /// <summary>
        /// Shows all trainers from the database
        /// </summary>
        public static void Trainers()
        {
            try
            {
                SqlConnection dbcon = new SqlConnection(connectionString);

                using (dbcon)
                {
                    dbcon.Open();
                    var cmd = new SqlCommand("select * from Trainer", dbcon);
                    var reader = cmd.ExecuteReader();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" ___________ ____________ ___________ _____________");
                    Console.WriteLine("| TrainerID | First Name | Last Name |   Subject   |");
                    Console.WriteLine(" ___________ ____________ ___________ _____________");

                    while (reader.Read())
                    {
                        var tid = reader["ID"];
                        var FirstName = reader["FirstName"];
                        var LastName = reader["LastName"];
                        var Subject = reader["Subject"];
                        

                        Console.WriteLine("|{0,11}|{1,12}|{2,11}|{3,13}|"
                            , tid, FirstName, LastName, Subject);

                    }

                    Console.WriteLine(" ___________ ____________ ___________ _____________");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally { }
        }
        /// <summary>
        /// Shows all students from the database
        /// </summary>
        public static void Students() 
        {
            try
            {
                SqlConnection dbcon = new SqlConnection(connectionString);

                using (dbcon)
                {
                    dbcon.Open();
                    var cmd = new SqlCommand("select * from Student", dbcon);
                    var reader = cmd.ExecuteReader();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" ___________ ____________ _____________ _______________ ______________");
                    Console.WriteLine("| StudentID | First Name |  Last Name  | Date of Birth | Tuition Fees |");
                    Console.WriteLine(" ___________ ____________ _____________ _______________ ______________");

                    while (reader.Read())
                    {
                        var sid = reader["ID"];
                        var FirstName = reader["FirstName"];
                        var LastName = reader["LastName"];
                        var DoB = Convert.ToDateTime(reader["DateOfBirth"]).ToString("d/M/yyyy");
                        var Fees = reader["TuitionFees"];


                        Console.WriteLine("|{0,11}|{1,12}|{2,13}|{3,15}|{4,14}|"
                            , sid, FirstName, LastName, DoB,Fees);

                    }

                    Console.WriteLine(" ___________ ____________ _____________ _______________ ______________");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally { }
        }
        /// <summary>
        /// Shows all assignments from the database
        /// </summary>
        public static void Assignments() 
        {
            try
            {
                SqlConnection dbcon = new SqlConnection(connectionString);

                using (dbcon)
                {
                    dbcon.Open();
                    var cmd = new SqlCommand("select * from Assignment", dbcon);
                    var reader = cmd.ExecuteReader();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" ______________ _____________________ _________________________________________________ ___________________________");
                    Console.WriteLine("| AssignmentID |        Title        |                   Description                   |   Submition Date & Time   |");
                    Console.WriteLine(" ______________ _____________________ _________________________________________________ ___________________________");
                    
                    while (reader.Read())
                    {
                        var aid = reader["ID"];
                        var Title = reader["Title"];
                        var Description = reader["Description"];
                        var SubDateTime = reader["SubDateTime"];


                        Console.WriteLine("|{0,14}|{1,21}|{2,49}|{3,27}|"
                            , aid, Title, Description, SubDateTime);

                    }

                    Console.WriteLine(" ______________ _____________________ _________________________________________________ ___________________________");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally { }
        }
        //=====================================================================
        /*
         * 
         * 
         * 
         */
        // Methods to view data from tables per "Course" table ================
        /// <summary>
        /// Shows all students categorized per Course
        /// </summary>
        public static void StudentsPerCourse() 
        {
            try
            {

                using (SqlConnection dbcon = new SqlConnection(connectionString))
                {
                    dbcon.Open();
                    var cmd = new SqlCommand("select C.Title, C.Stream, C.Type, S.FirstName, S.LastName, StudentId, CourseId " +
                                                "FROM Courses_Students SpC "+
                                                "INNER JOIN Student S on S.ID = SpC.StudentID "+
                                                "INNER JOIN Course  C on C.ID = SpC.CourseID " +
                                                "ORDER BY C.ID ASC", dbcon);
                    var reader = cmd.ExecuteReader();

                    int previousID = 0;
                    while (reader.Read())
                    {
                        int cid = Convert.ToInt32(reader["CourseId"]);
                        var sid = reader["StudentId"];
                        var FirstName = reader["FirstName"];
                        var LastName = reader["LastName"];
                        var Title = reader["Title"];
                        var Stream = reader["Stream"];
                        var Type = reader["Type"];

                        if (cid != previousID)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("In {0} with stream {1} on {2} are students:", Title, Stream, Type);
                            previousID = cid;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t{0} {1} with Student ID: {2}", FirstName,LastName,sid);
                        

                    }
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Could not show the data...");
                Console.WriteLine("Error type: " + e.Message);
            }
            finally { }

        }
        /// <summary>
        /// Shows all trainers categorized per Course
        /// </summary>
        public static void TrainersPerCourse() 
        {
            try
            {

                using (SqlConnection dbcon = new SqlConnection(connectionString))
                {
                    dbcon.Open();
                    var cmd = new SqlCommand("select C.Title, C.Stream, C.Type, T.FirstName, T.LastName, T.Subject, CourseId " +
                                                "FROM Course_Trainer TpC " +
                                                "INNER JOIN Trainer T on T.ID = TpC.TrainerID " +
                                                "INNER JOIN Course  C on C.ID = TpC.CourseID " +
                                                "ORDER BY C.ID ASC", dbcon);
                    var reader = cmd.ExecuteReader();

                    int previousID = 0;
                    while (reader.Read())
                    {
                        int cid = Convert.ToInt32(reader["CourseId"]);
                        var Subject = reader["Subject"];
                        var FirstName = reader["FirstName"];
                        var LastName = reader["LastName"];
                        var Title = reader["Title"];
                        var Stream = reader["Stream"];
                        var Type = reader["Type"];

                        if (cid != previousID)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("In {0} with stream {1} on {2} are trainer:", Title, Stream, Type);
                            previousID = cid;
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t{0} {1} with Subject: {2}", FirstName, LastName, Subject);


                    }
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Could not show the data...");
                Console.WriteLine("Error type: " + e.Message);
            }
            finally { }
        }
        /// <summary>
        /// Shows all assignments categorized per Course
        /// </summary>
        public static void AssignmentsPerCourse() 
        {
            try
            {

                using (SqlConnection dbcon = new SqlConnection(connectionString))
                {
                    dbcon.Open();
                    var cmd = new SqlCommand("select C.Title, C.Stream, C.Type, A.Title as Atitle, A.SubDateTime, CourseId " +
                                                "FROM AssignmentPerCoursePerStudent ApC " +
                                                "INNER JOIN Assignment A on A.ID = ApC.AssignmentID " +
                                                "INNER JOIN Course  C on C.ID = ApC.CourseID " +
                                                "ORDER BY C.ID ASC", dbcon);
                    var reader = cmd.ExecuteReader();

                    int previousID = 0;
                    while (reader.Read())
                    {
                        int cid = Convert.ToInt32(reader["CourseId"]);
                        var Atitle = reader["Atitle"];
                        var SubDateTime = reader["SubDateTime"];
                        var Title = reader["Title"];
                        var Stream = reader["Stream"];
                        var Type = reader["Type"];

                        if (cid != previousID)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("In {0} with stream {1} on {2} are assignments:", Title, Stream, Type);
                            previousID = cid;
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t{0} and expires at: {1}", Atitle, SubDateTime);


                    }
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Could not show the data...");
                Console.WriteLine("Error type: " + e.Message);
            }
            finally { }
        }
        /// <summary>
        /// Shows all assignments categorized per Course and per Student
        /// </summary>
        public static void AssignmentsPerCoursePerStudent() 
        {
            try
            {

                using (SqlConnection dbcon = new SqlConnection(connectionString))
                {
                    dbcon.Open(); 
                    var cmd = new SqlCommand("select C.Title, C.Stream, C.Type, A.Title as Atitle, A.SubDateTime, Submited, " +
                                             "OralMark, TotalMark, S.FirstName, S.LastName, AssignmentID, CourseId, StudentID " +
                                                "FROM AssignmentPerCoursePerStudent ApCpS " +
                                                "INNER JOIN Assignment A on A.ID = ApCpS.AssignmentID " +
                                                "INNER JOIN Course  C on C.ID = ApCpS.CourseID " +
                                                "INNER JOIN Student  S on S.ID = ApCpS.StudentID " +
                                                "ORDER BY A.ID, C.ID ASC", dbcon);
                    var reader = cmd.ExecuteReader();

                    int previousAID = -1;
                    int previousCID = -1;
                    while (reader.Read())
                    {
                        //Assignment values
                        int aid = Convert.ToInt32(reader["AssignmentID"]);
                        var Atitle = reader["Atitle"];
                        var OralMark = reader["OralMark"];
                        var TotalMark = reader["TotalMark"];
                        var Submited = bool.Parse(reader["Submited"].ToString());
                        //Course values
                        int cid = Convert.ToInt32(reader["CourseId"]);
                        var Title = reader["Title"];
                        var Stream = reader["Stream"];
                        var Type = reader["Type"];
                        //Student values
                        var sid = reader["StudentId"];
                        var FirstName = reader["FirstName"];
                        var LastName = reader["LastName"];

                        if (aid != previousAID)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The Assignment \"{0}: {1}\" on course:", aid, Atitle);
                            previousAID = aid;
                        }

                        if (cid != previousCID)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\t{0} in {1} class of {2} haves the student:", Title, Stream, Type);
                            previousCID = cid;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t{0} {1} with Student ID: {2}", FirstName, LastName, sid);

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (!Submited) { Console.WriteLine("\t\t=> Has not submitted the assignment yet!"); }
                        else if (OralMark.Equals(DBNull.Value) || TotalMark.Equals(DBNull.Value)) { Console.WriteLine("\t\t=> Rating in progress..."); }
                        else { Console.WriteLine("\t\t=> Oral Mark: {0}, Total Mark: {1}",OralMark,TotalMark); }

                    }
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Could not show the data...");
                Console.WriteLine("Error type: " + e.Message);
            }
            finally { }
        }
        /// <summary>
        /// Shows all the students that belongs to more than one Course
        /// </summary>
        public static void StudentsOver1Course() 
        {
            try
            {

                using (SqlConnection dbcon = new SqlConnection(connectionString))
                {
                    dbcon.Open();
                    var cmd = new SqlCommand("select FirstName, LastName, Title, Stream, StudentID, Type from Courses_Students cs " +
                                                "inner join Student S on cs.StudentID = s.ID "+
                                                "inner join Course C on cs.CourseID = c.ID " +
                                                "where StudentID in " +
                                                "(select StudentID " +
                                                "from Courses_Students cs " +
                                                "group by StudentID " +
                                                "having Count(CourseID) > 1)" +
                                                "order by StudentID ASC", dbcon);
                    var reader = cmd.ExecuteReader();

                    int previousID = 0;
                    while (reader.Read())
                    {
                        int sid = Convert.ToInt32(reader["StudentId"]);
                        
                        var FirstName = reader["FirstName"];
                        var LastName = reader["LastName"];
                        var Title = reader["Title"];
                        var Stream = reader["Stream"];
                        var Type = reader["Type"];

                        if (sid != previousID)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0} {1} spectates courses:", FirstName, LastName);
                            
                            previousID = sid;
                        }
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\t{0} with stream {1} on {2} class", Title, Stream, Type);



                    }
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Could not show the data...");
                Console.WriteLine("Error type: " + e.Message);
            }
            finally { }
        }
        //=====================================================================

    }
}
