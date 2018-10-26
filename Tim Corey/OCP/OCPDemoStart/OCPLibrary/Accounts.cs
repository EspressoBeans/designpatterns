using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary
{
    public class Accounts
    {
        //open closed principle says that once this working modularized code is in production, you shouldn't have to change it, instead just extend it.
        public EmployeeModel Create(PersonModel person)
        {
            EmployeeModel output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            output.EmailAddress = $"{ person.FirstName.Substring(0, 1) }{person.LastName}@acme.com";

            //*****
            //newer code which violates the OCP because we've updated the create method in order to set a new employee as manager.  we've created a public enum which holds employee types
            //referenced here.
            if (person.TypeOfEmployee == EmployeeType.Manager)
            {
                output.IsManager = true;
            }

            //******
            //even newer code which now accounts for manager and executive, this is a WORSE offense to OCP because we've further updated the create method with having to determine employee type
            //after we had basic working code.  also we've introduced potential new bugs in our system - so every time we have to add a new type of employee to our program, we'll have to 
            //come back here and add it to this switch statement - NO GOOD.
            switch (person.TypeOfEmployee)
            {
                case EmployeeType.Staff:
                    break;
                case EmployeeType.Manager:
                    output.IsManager = true;
                    break;
                case EmployeeType.Executive:
                    output.IsExecutive = true;
                    break;
                default:
                    break;
            }

            return output;
        }
    }
}
