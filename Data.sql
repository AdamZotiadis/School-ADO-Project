	-- Course Values (4)
insert into Course  (Title, Stream, Type, StartDate, EndDate)
values ('CB8','C#','Full-Time','2019-1-1','2019-3-31');
insert into Course  (Title, Stream, Type, StartDate, EndDate)
values ('CB8','Java','Full-Time','2019-1-1','2019-3-31');
insert into Course  (Title, Stream, Type, StartDate, EndDate)
values ('CB8','C#','Part-Time','2019-1-1','2019-7-31');
insert into Course  (Title, Stream, Type, StartDate, EndDate)
values ('CB8','Java','Part-Time','2019-1-1','2019-7-31');

	--Trainer Values (8)
insert into Trainer (Firstname, LastName, Subject)
 values ('John','Sins','Input-Output');
insert into Trainer (Firstname, LastName, Subject)
 values ('Lisa','Ann','Back End');
insert into Trainer (Firstname, LastName, Subject)
 values ('Aimee','Tyler','Front-End');
insert into Trainer (Firstname, LastName, Subject)
 values ('Kennedy','Leigh','Data Analist');
insert into Trainer (Firstname, LastName, Subject)
 values ('Arthour','Makenda','MVC');
insert into Trainer (Firstname, LastName, Subject)
 values ('Ian','Jackson','Introduction');
insert into Trainer (Firstname, LastName, Subject)
 values ('Sarah','Vandella','Connections');
insert into Trainer (Firstname, LastName, Subject)
 values ('Asa','Akira','Testing');

	--Student Values (13)
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Adam','Zots','1996-8-16',2500);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Jennifer','White','1990-2-13',3100);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Alison','Tyler','1993-8-3',3500);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Alex','Grey','1999-11-22',2250);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Eric','Levi','1988-4-19',4000);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Monique','Fuentes','1991-5-28',2800);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Abella','Danger','1997-3-21',3469);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Morgan','Lee','1994-12-9',2000);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Tony','Sanchez','1989-1-24',1890);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Kenzie','Madison','1997-3-20',3900);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('George','Papadopoulos','1997-2-1',2400);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Antonis','Ioannou','1991-7-19',5000);
insert into Student (FirstName, LastName, DateOfBirth, TuitionFees)
 values ('Adriana','Chechik','1995-4-6',6969);

	--Assignment Values (4)
insert into Assignment (Title, Description, SubDateTime)
 values ('Back-End','Project to exercise in the programming language','2019-1-31 23:59');
insert into Assignment (Title, Description, SubDateTime)
 values ('Database (MSSQL)','Project to exercise in the database','2019-2-15 23:59');
insert into Assignment (Title, Description, SubDateTime)
 values ('Front-End','Project to exercise in the web interface','2019-4-6 22:00');
insert into Assignment (Title, Description, SubDateTime)
 values ('Full Stack','Project to exercise all lessons','2019-7-18 23:59');

	--Trainers per Course
insert into Course_Trainer (CourseID, TrainerID)
 values (1,1);
insert into Course_Trainer (CourseID, TrainerID)
 values (2,2);
insert into Course_Trainer (CourseID, TrainerID)
 values (3,3);
insert into Course_Trainer (CourseID, TrainerID)
 values (4,4);
insert into Course_Trainer (CourseID, TrainerID)
 values (1,5);
insert into Course_Trainer (CourseID, TrainerID)
 values (2,6);
insert into Course_Trainer (CourseID, TrainerID)
 values (3,7);
insert into Course_Trainer (CourseID, TrainerID)
 values (4,8);

	--Students per Course
insert into Courses_Students (CourseID, StudentID)
 values(1,1);
insert into Courses_Students (CourseID, StudentID)
 values(2,2);
insert into Courses_Students (CourseID, StudentID)
 values(3,3);
insert into Courses_Students (CourseID, StudentID)
 values(4,4);
insert into Courses_Students (CourseID, StudentID)
 values(1,5);
insert into Courses_Students (CourseID, StudentID)
 values(2,6);
insert into Courses_Students (CourseID, StudentID)
 values(3,7);
insert into Courses_Students (CourseID, StudentID)
 values(4,8);
insert into Courses_Students (CourseID, StudentID)
 values(1,9);
insert into Courses_Students (CourseID, StudentID)
 values(2,10);
insert into Courses_Students (CourseID, StudentID)
 values(3,11);
insert into Courses_Students (CourseID, StudentID)
 values(4,12);
insert into Courses_Students (CourseID, StudentID)
 values(1,13);
insert into Courses_Students (CourseID, StudentID)
 values(2,1);
insert into Courses_Students (CourseID, StudentID)
 values(3,2);
insert into Courses_Students (CourseID, StudentID)
 values(4,3);
insert into Courses_Students (CourseID, StudentID)
 values(1,6);
insert into Courses_Students (CourseID, StudentID)
 values(2,8);
insert into Courses_Students (CourseID, StudentID)
 values(3,12);
insert into Courses_Students (CourseID, StudentID)
 values(4,9);

	--Assignment per course per student
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values (1,1,1,100,100,1)
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(2,2,2,53,49,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, Submited)
 values(3,3,3,0);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(4,4,4,55,88,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, Submited)
 values(1,5,1,0);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(2,6,2,80,99,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, Submited)
 values(3,7,3,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(4,8,4,100,88,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(1,9,1,20,48,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(2,10,2,52,66,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, Submited)
 values(3,11,3,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, Submited)
 values(4,12,4,0);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(1,13,2,0,0,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(2,1,1,69,69,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(3,2,4,44,23,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, Submited)
 values(4,3,3,0);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, Submited)
 values(1,6,2,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(2,8,1,1,8,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(3,12,3,32,87,1);
insert into AssignmentPerCoursePerStudent(CourseID, StudentID, AssignmentID, OralMark, TotalMark, Submited)
 values(4,9,4,69,77,1);