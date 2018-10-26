using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console; 

namespace LiskovSubstitution2
{
    //https://www.youtube.com/watch?v=-3UXq2krhyw
    //TODO: LISKOV PRINCIPLE NOT APPLIED TO THIS CODE YET.  WATCH VIDEO WALKTHROUGH TO CORRECT CODE TO BE LISKOV COMPLIANT.

    public abstract class BaseEmployee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public virtual void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 12.50M;
            Salary = baseAmount + (rank * 2);
        }
    }
    public class Employee : BaseEmployee, IManaged
    {
  
        public IEmployee Manager { get; set; } = null;


        public virtual void AssignManager(IEmployee manager)
        {
            //Simulate doing other tasks here - otherwise, this should be
            //a property set statement, not a method
            Manager = manager;
        }

    }

    public class Manager : Employee, IManager
    {
        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 19.75M;
            Salary = baseAmount + (rank * 4);
        }

        public void GeneratePerformanceReview()
        {
            //Simulate reviewing a direct report
            WriteLine("I'm reviewing a direct report's performance.");
        }
    }

    public class CEO : BaseEmployee, IManager
    {
        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 150M;
            Salary = baseAmount * rank;
        }

        public void GeneratePerformanceReview()
        {
            //Simulate reviewing a direct report
            WriteLine("I'm reviewing a direct report's performance.");
        }

        public void FireSomeone()
        {
            WriteLine("You're Fired!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IManager accountingVP = new CEO();

            accountingVP.FirstName = "Emma";
            accountingVP.LastName = "Stone";
            accountingVP.CalculatePerHourRate(4);

            WriteLine($"{ accountingVP.FirstName}'s salary is {accountingVP.Salary}/hour.");

            IManaged emp = new Employee();

            emp.FirstName = "Tim";
            emp.LastName = "Corey";
            emp.AssignManager(accountingVP);
            emp.CalculatePerHourRate(2);

            WriteLine($"{ emp.FirstName}'s salary is {emp.Salary}/hour.");
         
        }
    }
}
