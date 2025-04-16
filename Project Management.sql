CREATE DATABASE ProjectManagement
USE ProjectManagement

CREATE TABLE Project
(
Id int PRIMARY KEY,
ProjectName varchar(100) NOT NULL,
Description varchar(max),
StartDate date NOT NULL,
Status varchar(20) CHECK (Status IN('started', 'dev', 'build', 'test', 'deployed')) NOT NULL
)

CREATE TABLE Employee
(
Id int PRIMARY KEY,
Name varchar(30) NOT NULL,
Designation varchar(30) NOT NULL,
Gender varchar(30) NOT NULL ,
Salary decimal(10,2),
Project_id int,
CONSTRAINT fk_projectid FOREIGN KEY(Project_id) REFERENCES Project(Id)
)

CREATE TABLE Task (
    Task_id INT PRIMARY KEY,
    Task_name VARCHAR(100) NOT NULL,
    Project_id INT,
    Employee_id INT,
    Status VARCHAR(20) CHECK (Status IN ('Assigned', 'Started', 'Completed')),
    CONSTRAINT fk_task_projectid FOREIGN KEY (Project_id) REFERENCES Project(Id) ON DELETE CASCADE,
    CONSTRAINT fk_task_employeeid FOREIGN KEY (Employee_id) REFERENCES Employee(Id) ON DELETE SET NULL
)

SELECT * FROM Project
SELECT * FROM Employee
SELECT * FROM Task
