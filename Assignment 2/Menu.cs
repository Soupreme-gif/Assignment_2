namespace Assignment_2;

public class Menu
{
    public void DisplayMenu()
    {

        for(int i = 0; i < Int32.MaxValue; i++)
        {
            HrPerson interviewer = new HrPerson();

            Console.WriteLine("Hire an Employee?");
            String response = Console.ReadLine();

            if(response == "yes" || response == "Yes")
            {

                bool hiredEmployee = interviewer.Interview();

                if(hiredEmployee == true)
                {
                    Console.WriteLine("What is the Employee's first name?");
                    String name = Console.ReadLine();

                    Console.WriteLine("What is the Employee's last name?");
                    String lastName = Console.ReadLine();

                    Console.WriteLine("Enter in the employee's SSN");
                    String ssn = Console.ReadLine();

                    Employee employee = new Employee(name, lastName, ssn);
                    employee.doFirstTimeOrientation("A101");
                    employee.printReport();

                }


            }

        }

    }
}