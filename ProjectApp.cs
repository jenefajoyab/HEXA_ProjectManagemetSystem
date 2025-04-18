using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.DAO;
using ProjectManagement.Entity;

namespace ProjectManagement
{
    public class ProjectApp
    {
        static void Main(string[] args)
        {
            ProjectRepositoryImpl repo = new ProjectRepositoryImpl();
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n==== Project Management Menu ====");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Add Project");
                Console.WriteLine("3. Add Task");
                Console.WriteLine("4. Assign Project to Employee");
                Console.WriteLine("5. Assign Task to Employee in Project");
                Console.WriteLine("6. Delete Employee");
                Console.WriteLine("7. Delete Project");
                Console.WriteLine("8. View All Tasks for an Employee");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter employee id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter designation: ");
                            string designation = Console.ReadLine();
                            Console.Write("Enter gender: ");
                            string gender = Console.ReadLine();
                            Console.Write("Enter salary: ");
                            decimal salary = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter project ID: ");
                            int project_id = Convert.ToInt32(Console.ReadLine());
                            Employee emp = new Employee(id, name, designation, gender, salary, project_id);
                            repo.CreateEmployee(emp);
                            Console.WriteLine("Employee added.");
                            break;
                        case 2:
                            Console.Write("Enter project id: ");
                            int projid = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter project name: ");
                            string projectName = Console.ReadLine();
                            Console.Write("Enter description: ");
                            string description = Console.ReadLine();
                            Console.Write("Enter start date (yyyy-mm-dd): ");
                            DateTime startDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter status (started/dev/build/test/deployed): ");
                            string status = Console.ReadLine();
                            Project project = new Project(projid, projectName, description, startDate, status);
                            repo.CreateProject(project);
                            Console.WriteLine("Project created.");
                            break;
                        case 3:
                            Console.Write("Enter task id: ");
                            int taskid = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter task name: ");
                            string taskName = Console.ReadLine();
                            Console.Write("Enter project ID: ");
                            int taskprojId = int.Parse(Console.ReadLine());
                            Console.Write("Enter employee ID: ");
                            int taskempId = int.Parse(Console.ReadLine());
                            Console.Write("Enter task status (Assigned/Started/Completed): ");
                            string taskStatus = Console.ReadLine();
                            var task = new ProjectManagement.Entity.Task(taskid, taskName, taskprojId, taskempId, taskStatus);
                            repo.CreateTask(task);
                            Console.WriteLine("Task created.");
                            break;
                        case 4:
                            Console.Write("Enter project ID: ");
                            int pid = int.Parse(Console.ReadLine());
                            Console.Write("Enter employee ID: ");
                            int eid = int.Parse(Console.ReadLine());
                            repo.AssignProjectToEmployee(pid, eid);
                            Console.WriteLine("Project assigned.");
                            break;
                        case 5:
                            Console.Write("Enter task ID: ");
                            int tid = int.Parse(Console.ReadLine());
                            Console.Write("Enter project ID: ");
                            int projID = int.Parse(Console.ReadLine());
                            Console.Write("Enter employee ID: ");
                            int empID = int.Parse(Console.ReadLine());
                            repo.AssignTaskToEmployee(tid, projID, empID);
                            Console.WriteLine("Task assigned.");
                            break;
                        case 6:
                            Console.Write("Enter employee ID to delete: ");
                            int delEmpId = int.Parse(Console.ReadLine());
                            repo.DeleteEmployee(delEmpId);
                            Console.WriteLine("Employee deleted.");
                            break;
                        case 7:
                            Console.Write("Enter project ID to delete: ");
                            int delProjId = int.Parse(Console.ReadLine());
                            repo.DeleteProject(delProjId);
                            Console.WriteLine("Project deleted.");
                            break;
                        case 8:
                            Console.Write("Enter employee ID: ");
                            int empId = int.Parse(Console.ReadLine());
                            Console.Write("Enter project ID: ");
                            int projId = int.Parse(Console.ReadLine());
                            var tasks = repo.GetAllTasks(empId, projId);
                            Console.WriteLine("Assigned Tasks:");
                            foreach (var t in tasks)
                            {
                                Console.WriteLine($"{t.TaskName} (Status: {t.Status})");
                            }
                            break;
                        case "9":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
