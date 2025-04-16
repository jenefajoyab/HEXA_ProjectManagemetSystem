using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entity;

namespace ProjectManagement.DAO
{
    public interface IProjectRepository
    {
        bool CreateEmployee(Employee emp);
        bool CreateProject(Project proj);
        bool CreateTask(ProjectManagement.Entity.Task task);
        bool AssignProjectToEmployee(int projectId, int employeeId);
        bool AssignTaskToEmployee(int taskId, int projectId, int employeeId);
        bool DeleteEmployee(int employeeId);
        bool DeleteProject(int projectId);
        List<ProjectManagement.Entity.Task> GetAllTasks(int empId, int projectId);
    }
}