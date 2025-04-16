using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Exceptions
{
    public class ProjectNotFoundException : Exception
    {
        public ProjectNotFoundException(string msg) : base(msg) { }
    }
}