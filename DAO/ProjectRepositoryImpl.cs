using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entity;
using ProjectManagement.Util;
using ProjectManagement.Exceptions;

namespace ProjectManagement.DAO
{
    public class ProjectRepositoryImpl
    {
        public bool CreateEmployee(Employee emp)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection()) //create connection object
            {
                conn.Open();// open a connection to SQL Server database 
                string query = "INSERT INTO Employee (Id,Name, Designation, Gender, Salary, Project_id) VALUES (@id,@name, @designation, @gender, @salary, @Project_id)";
                //inserting values
                using (SqlCommand cmd = new SqlCommand(query, conn))//create sql command object
                {
                    cmd.Parameters.AddWithValue("@id", emp.Id);
                    cmd.Parameters.AddWithValue("@name", emp.Name);
                    cmd.Parameters.AddWithValue("@designation", emp.Designation);
                    cmd.Parameters.AddWithValue("@gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@Project_id", emp.Project_id);

                    return cmd.ExecuteNonQuery() > 0;// returns true if rows are affected
                }
            }
        }
        public bool CreateProject(Project proj)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Project (Id,ProjectName, Description, StartDate, Status) VALUES (@projectid,@name, @desc, @date, @status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@projectid", proj.Id);
                cmd.Parameters.AddWithValue("@name", proj.Name);
                cmd.Parameters.AddWithValue("@desc", proj.Description);
                cmd.Parameters.AddWithValue("@date", proj.StartDate);
                cmd.Parameters.AddWithValue("@status", proj.Status);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool CreateTask(ProjectManagement.Entity.Task task)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Task (Task_id,Task_name, Project_id, Employee_id, Status) VALUES (@taskid,@name, @projectId, @empId, @status)";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@taskid", task.TaskId);
                cmd.Parameters.AddWithValue("@name", task.TaskName);
                cmd.Parameters.AddWithValue("@projectId", task.ProjectId);
                cmd.Parameters.AddWithValue("@empId", task.EmployeeId);
                cmd.Parameters.AddWithValue("@status", task.Status);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool AssignProjectToEmployee(int projectId, int employeeId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Employee SET Project_id = @projectId WHERE Id = @empId";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@projectId", projectId);
                cmd.Parameters.AddWithValue("@empId", employeeId);
                int rows = cmd.ExecuteNonQuery();
                if (rows == 0) throw new EmployeeNotFoundException($"Employee with ID {employeeId} not found.");
                return true;
            }
        }
        public bool AssignTaskToEmployee(int taskId, int projectId, int employeeId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Task SET Project_id = @projectId, Employee_id = @empId WHERE Task_id = @taskId";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@taskId", taskId);
                cmd.Parameters.AddWithValue("@projectId", projectId);
                cmd.Parameters.AddWithValue("@empId", employeeId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool DeleteEmployee(int employeeId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Employee WHERE Id = @id";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@id", employeeId);
                int rows = cmd.ExecuteNonQuery();
                if (rows == 0) throw new EmployeeNotFoundException($"Employee with ID {employeeId} not found.");
                return true;
            }
        }
        public bool DeleteProject(int projectId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Project WHERE Id = @id";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@id", projectId);
                int rows = cmd.ExecuteNonQuery();
                if (rows == 0) throw new ProjectNotFoundException($"Project with ID {projectId} not found.");
                return true;
            }
        }
        public List<ProjectManagement.Entity.Task> GetAllTasks(int empId, int projectId)
        {
            List<ProjectManagement.Entity.Task> tasks = new List<ProjectManagement.Entity.Task>();
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT Task_id, Task_name, Project_id, Employee_id, Status FROM Task WHERE Employee_id = @empId AND Project_id = @projectId";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.Parameters.AddWithValue("@projectId", projectId);
                using SqlDataReader reader = cmd.ExecuteReader();//reading data from a SQL Server database
                while (reader.Read())
                {
                    ProjectManagement.Entity.Task task = new ProjectManagement.Entity.Task(
                         taskId: reader.GetInt32(0),
                         taskName: reader.GetString(1),
                         projecId: reader.GetInt32(2),
                         employeeId: reader.GetInt32(3),
                         status: reader.GetString(4)
                    );// object initialization with named parameter
                    tasks.Add(task);
                }
                return tasks;
            }
        }
    }
}
