using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgetTheMilkk.Controllers;

namespace ConsoleVerification
{
    class Program
    {
        static void Main(string[] args)
        {

            TestDescAndNoDueDate();
            TestMayDueDateDoesWrapYear();
            TestMayDueDateDoesNotWrapYear();

            //Console.WriteLine("Description: " + task.Description);
            Console.ReadLine();
        }

        private static void TestDescAndNoDueDate()
        {
            var input = "pick up the groceries";
            Console.WriteLine("Scenario:" + input);

            var task = new ForgetTheMilkk.Controllers.Task(input, default(DateTime));

            var descriptionShouldBe = input;
            DateTime? dateShouldBe = null;
            var success = descriptionShouldBe == task.Description && dateShouldBe == task.DueDate;
            var failureMessage = "Description: " + task.Description + " should be (" + descriptionShouldBe + ")"
                             + Environment.NewLine
                                + "Due date: " + task.DueDate + "should be " + dateShouldBe;
            PrintOutCome(success, failureMessage);
        }

        private static void PrintOutCome(bool success, string failureMessage)
        {
            if (success)
            {
                Console.WriteLine("Successful");
            }
            else
            {
                Console.WriteLine("Error occured: ");
                Console.WriteLine(failureMessage);
            }
            Console.WriteLine();
        }

        private static void TestMayDueDateDoesNotWrapYear()
        {
            var input = "pick up groceries may 5";
            var today = new DateTime(2016, 5, 5);
            Console.WriteLine("Scenario:" + input);

            var task = new ForgetTheMilkk.Controllers.Task(input, today);

            var dateShouldBe = new DateTime(2017, 5, 5);
            var success = dateShouldBe == task.DueDate;
            var failureMessage = "Due date: " + task.DueDate + "should be (" + dateShouldBe + ")";
            PrintOutCome(success, failureMessage);
        }
        private static void TestMayDueDateDoesWrapYear()
        {
            var input = "pick up groceries may 5";
            Console.WriteLine("Scenario:" + input);
            var today = new DateTime(2016, 5, 5);
            var task = new ForgetTheMilkk.Controllers.Task(input, today);

            var dateShouldBe = new DateTime(2017, 5, 5);
            var success = dateShouldBe == task.DueDate;
            var failureMessage = "Due date: " + task.DueDate + "should be (" + dateShouldBe + ")";
            PrintOutCome(success, failureMessage);
        }
    }
}
