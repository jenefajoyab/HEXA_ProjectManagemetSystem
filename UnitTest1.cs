using NUnit.Framework;
using ProjectManagement.DAO;
using ProjectManagement.Entity;
using ProjectManagement.Exceptions;
using System;
using System.Collections.Generic;

namespace ProjectManagement.Tests
{
    [TestFixture]
    public class ProjectRepositoryTests
    {
        private ProjectRepositoryImpl _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new ProjectRepositoryImpl();
        }

        [Test]
        public void Test_EmployeeCreatedSuccessfully()
        {
            int empId = 50;
            int projectId = 50;

            // Setup: Create project first (if needed)
            try { _repo.CreateProject(new Project(projectId, "Test Proj 1", "For Employee", DateTime.Now, "Started")); } catch { }

            var emp = new Employee(empId, "Test User", "Developer", "Male", 60000m, projectId);
            try { _repo.DeleteEmployee(empId); } catch { } // Cleanup in case exists
            bool result = _repo.CreateEmployee(emp);
            Assert.That(result, Is.True, "Employee should be created successfully.");
        }

        [Test]
        public void Test_ProjectCreatedSuccessfully()
        {
            int projectId = 51;
            var project = new Project(projectId, "Test Project", "A dummy project", DateTime.Now, "Started");
            try { _repo.DeleteProject(projectId); } catch { } // Cleanup in case exists
            bool result = _repo.CreateProject(project);
            Assert.That(result, Is.True, "Project should be created successfully.");
        }

        [Test]
        public void Test_TaskCreatedSuccessfully()
        {
            int projectId = 52;
            int employeeId = 52;
            int taskId = 52;

            try { _repo.CreateProject(new Project(projectId, "Test Project T", "Project for task", DateTime.Now, "Started")); } catch { }
            try { _repo.CreateEmployee(new Employee(employeeId, "Jane Doe", "Developer", "Female", 60000m, projectId)); } catch { }

            var task = new ProjectManagement.Entity.Task(taskId, "Develop Feature", projectId, employeeId, "Assigned");
            bool result = _repo.CreateTask(task);
            Assert.That(result, Is.True, "Task should be created successfully.");
        }

        [Test]
        public void Test_GetAllTasksForEmployee_ReturnsList()
        {
            int projectId = 53;
            int employeeId = 53;
            int taskId = 53;

            try { _repo.CreateProject(new Project(projectId, "Proj A", "Project A Desc", DateTime.Now, "Started")); } catch { }
            try { _repo.CreateEmployee(new Employee(employeeId, "Alex Smith", "Tester", "Male", 50000m, projectId)); } catch { }
            try { _repo.CreateTask(new ProjectManagement.Entity.Task(taskId, "Write TestCases", projectId, employeeId, "Assigned")); } catch { }

            var tasks = _repo.GetAllTasks(employeeId, projectId);
            Assert.That(tasks, Is.Not.Null);
            Assert.That(tasks, Is.InstanceOf<List<ProjectManagement.Entity.Task>>());
        }

        [Test]
        public void Test_EmployeeNotFoundException_Thrown()
        {
            int nonExistentEmpId = 100;
            var ex = Assert.Throws<EmployeeNotFoundException>(() => _repo.DeleteEmployee(nonExistentEmpId));
            Assert.That(ex.Message, Does.Contain("Employee with ID"));
        }

        [Test]
        public void Test_ProjectNotFoundException_Thrown()
        {
            int nonExistentProjId = 100;
            var ex = Assert.Throws<ProjectNotFoundException>(() => _repo.DeleteProject(nonExistentProjId));
            Assert.That(ex.Message, Does.Contain("Project with ID"));
        }
    }
}
