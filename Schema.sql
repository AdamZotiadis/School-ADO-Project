CREATE TABLE Course (
  ID        int IDENTITY NOT NULL, 
  Title     varchar(20) NOT NULL, 
  Stream    varchar(15) NOT NULL, 
  Type      varchar(20) NOT NULL, 
  StartDate date NOT NULL, 
  EndDate   date NOT NULL, 
  PRIMARY KEY (ID));

CREATE TABLE Student (
  ID          int IDENTITY NOT NULL, 
  FirstName   varchar(25) NOT NULL, 
  LastName    varchar(25) NOT NULL, 
  DateOfBirth date NOT NULL, 
  TuitionFees decimal(8, 2) NULL, 
  PRIMARY KEY (ID));

CREATE TABLE Trainer (
  ID        int IDENTITY NOT NULL, 
  FirstName varchar(25) NOT NULL, 
  LastName  varchar(25) NOT NULL, 
  Subject   varchar(25) NOT NULL, 
  PRIMARY KEY (ID));

CREATE TABLE Assignment (
  ID          int IDENTITY NOT NULL, 
  Title       varchar(25) NOT NULL, 
  Description varchar(255) NULL, 
  SubDateTime datetime NOT NULL, 
  PRIMARY KEY (ID));


CREATE TABLE Course_Trainer (
  CourseID  int NOT NULL, 
  TrainerID int NOT NULL, 
  PRIMARY KEY (CourseID, 
  TrainerID));

ALTER TABLE Course_Trainer ADD CONSTRAINT FKCourse_Tra590771 FOREIGN KEY (TrainerID) REFERENCES Trainer (ID);
ALTER TABLE Course_Trainer ADD CONSTRAINT FKCourse_Tra144698 FOREIGN KEY (CourseID) REFERENCES Course (ID);

CREATE TABLE Courses_Students (
  CourseID  int NOT NULL, 
  StudentID int NOT NULL, 
  PRIMARY KEY (CourseID, 
  StudentID));

ALTER TABLE Courses_Students ADD CONSTRAINT FKCourses_St152471 FOREIGN KEY (CourseID) REFERENCES Course (ID);
ALTER TABLE Courses_Students ADD CONSTRAINT FKCourses_St890456 FOREIGN KEY (StudentID) REFERENCES Student (ID);

CREATE TABLE AssignmentPerCoursePerStudent (
  StudentID    int NOT NULL, 
  CourseID     int NOT NULL, 
  AssignmentID int NOT NULL, 
  OralMark     int NULL, 
  TotalMark    int NULL, 
  Submited     bit NOT NULL,
  PRIMARY KEY (CourseID, 
  StudentID, AssignmentID));

ALTER TABLE AssignmentPerCoursePerStudent ADD CONSTRAINT FKAssignment242085 FOREIGN KEY (AssignmentID) REFERENCES Assignment (ID);
ALTER TABLE AssignmentPerCoursePerStudent ADD CONSTRAINT FKAssignment238841 FOREIGN KEY (CourseID) REFERENCES Course (ID);
ALTER TABLE AssignmentPerCoursePerStudent ADD CONSTRAINT FKAssignment689821 FOREIGN KEY (StudentID) REFERENCES Student (ID);

