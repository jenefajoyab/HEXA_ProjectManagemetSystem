using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Entity
    {
        public class Project
        {
            private int id;
            private string projectName;
            private string description;
            private DateTime startDate;
            private string status;
            public Project() { }
            public Project(int id, string ProjectName, string Description, DateTime startDate, string status)
            {
                this.id = id;
                this.projectName = ProjectName;
                this.description = Description;
                this.startDate = startDate;
                this.status = status;
            }
            public int Id { get => id; set => id = value; }
            public string Name { get => projectName; set => projectName = value; }
            public string Description { get => description; set => description = value; }
            public DateTime StartDate { get => startDate; set => startDate = value; }
            public string Status { get => status; set => status = value; }
        }
    }
