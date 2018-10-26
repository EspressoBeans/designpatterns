using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //this is the new prop
        public EmployeeType TypeOfEmployee { get; set; } = EmployeeType.Staff;
    }
}
