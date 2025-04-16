using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Entity
{
    public class Task
    {
        private int taskId;
        private string taskName;
        private int projectId;
        private int employeeId;
        private string status;
        public Task() { }
        public Task(int taskId, string taskName, int projecId, int employeeId, string status)
        {
            this.taskId = taskId;
            this.taskName = taskName;
            this.projectId = projecId;
            this.employeeId = employeeId;
            this.status = status;
        }
        public int TaskId { get => taskId; set => taskId = value; }
        public string TaskName { get => taskName; set => taskName = value; }
        public int ProjectId { get => projectId; set => projectId = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string Status { get => status; set => status = value; }
    }
}