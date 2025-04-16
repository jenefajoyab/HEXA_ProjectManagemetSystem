using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Entity
{
    public class Employee
    {
        private int id;
        private string name;
        private string designation;
        private string gender;
        private decimal salary;
        private int project_id;

        public Employee() { }

        public Employee(int id, string name, string designation, string gender, decimal salary, int project_id)
        {
            this.id = id;
            this.name = name;
            this.designation = designation;
            this.gender = gender;
            this.salary = salary;
            this.project_id = project_id;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Designation { get => designation; set => designation = value; }
        public string Gender { get => gender; set => gender = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public int Project_id { get => project_id; set => project_id = value; }
    }

}